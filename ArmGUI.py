import sys
import os
import tkinter as tk
from tkinter import ttk
import numpy as np
import time

# =============================================================================
# QUANSER SDK PATH SETUP - MODIFY THIS PATH BASED ON YOUR INSTALLATION
# =============================================================================
QUANSER_PATHS = [
    r"C:\Program Files\Quanser\QUARC\python",
    r"C:\Quanser\QUARC\python", 
    r"C:\Program Files (x86)\Quanser\QUARC\python",
]

for path in QUANSER_PATHS:
    if os.path.exists(path):
        sys.path.insert(0, path)
        break
else:
    print("ERROR: Could not find Quanser SDK path!")
    print("Please modify the QUANSER_PATHS list with the correct path.")
    sys.exit(1)

# Now import Quanser modules
try:
    from quanser.hardware import HIL, HILError, MAX_STRING_LENGTH, Clock
    from quanser.hardware.enumerations import BufferOverflowMode
    print("SUCCESS: Quanser modules imported successfully!")
except ImportError as e:
    print(f"ERROR: Could not import Quanser modules: {e}")
    sys.exit(1)

# Import your existing QArm classes
from Libraries.hal.products.qarm import QArmUtilities
from Libraries.pal.products.qarm import QArm

class QArmGUI:
    def __init__(self):
        # Initialize QArm
        self.qarm = QArm()
        self.qarm_util = QArmUtilities()
        
        # Initialize joint angles (in radians)
        self.current_joints = np.array([0.0, 0.0, 0.0, 0.0], dtype=np.float64)
        self.current_gripper = np.array([0.1], dtype=np.float64)  # Open position
        
        # Joint limits in degrees (from the _check_joint_limits method)
        self.joint_limits = {
            'base': (-170, 170),
            'shoulder': (-80, 80),
            'elbow': (-95, 75),
            'wrist': (-160, 160)
        }
        
        # Gripper limits (from the code: 0.1 open, 0.9 close)
        self.gripper_limits = (0.1, 0.9)
        
        self.setup_gui()
        
    def setup_gui(self):
        # Create main window
        self.root = tk.Tk()
        self.root.title("Quanser QArm Manual Control")
        self.root.geometry("400x500")
        
        # Style configuration
        style = ttk.Style()
        style.configure("TLabel", font=("Arial", 10))
        style.configure("TButton", font=("Arial", 10))
        
        # Main frame
        main_frame = ttk.Frame(self.root, padding="10")
        main_frame.grid(row=0, column=0, sticky=(tk.W, tk.E, tk.N, tk.S))
        
        # Title
        title_label = ttk.Label(main_frame, text="QArm Joint Control", font=("Arial", 14, "bold"))
        title_label.grid(row=0, column=0, columnspan=2, pady=(0, 20))
        
        # Joint sliders
        self.sliders = {}
        self.slider_vars = {}
        self.value_labels = {}
        
        # Base joint slider
        self.create_joint_slider(main_frame, "base", "Base Rotation", 1, self.joint_limits['base'])
        
        # Shoulder joint slider  
        self.create_joint_slider(main_frame, "shoulder", "Shoulder", 2, self.joint_limits['shoulder'])
        
        # Elbow joint slider
        self.create_joint_slider(main_frame, "elbow", "Elbow", 3, self.joint_limits['elbow'])
        
        # Wrist joint slider
        self.create_joint_slider(main_frame, "wrist", "Wrist", 4, self.joint_limits['wrist'])
        
        # Gripper slider
        self.create_gripper_slider(main_frame, 5)
        
        # Control buttons
        button_frame = ttk.Frame(main_frame)
        button_frame.grid(row=6, column=0, columnspan=2, pady=20)
        
        home_btn = ttk.Button(button_frame, text="Home Position", command=self.home_position)
        home_btn.grid(row=0, column=0, padx=5)
        
        read_btn = ttk.Button(button_frame, text="Read Current Position", command=self.read_current_position)
        read_btn.grid(row=0, column=1, padx=5)
        
        # Status label
        self.status_label = ttk.Label(main_frame, text="Ready - Move sliders to control arm", foreground="green")
        self.status_label.grid(row=7, column=0, columnspan=2, pady=10)
        
        # Configure grid weights
        self.root.columnconfigure(0, weight=1)
        self.root.rowconfigure(0, weight=1)
        main_frame.columnconfigure(1, weight=1)
        
    def create_joint_slider(self, parent, joint_name, display_name, row, limits):
        """Create a slider for a joint with labels and value display"""
        # Label
        label = ttk.Label(parent, text=f"{display_name} (°):")
        label.grid(row=row, column=0, sticky=tk.W, pady=5)
        
        # Value display
        self.value_labels[joint_name] = ttk.Label(parent, text="0.0°")
        self.value_labels[joint_name].grid(row=row, column=2, sticky=tk.E, padx=(10, 0), pady=5)
        
        # Slider variable
        self.slider_vars[joint_name] = tk.DoubleVar(value=0.0)
        
        # Slider
        self.sliders[joint_name] = ttk.Scale(
            parent, 
            from_=limits[0], 
            to=limits[1], 
            variable=self.slider_vars[joint_name],
            orient=tk.HORIZONTAL,
            command=lambda val, name=joint_name: self.on_slider_move(val, name)
        )
        self.sliders[joint_name].grid(row=row, column=1, sticky=(tk.W, tk.E), pady=5)
        
    def create_gripper_slider(self, parent, row):
        """Create a slider for the gripper"""
        # Label
        label = ttk.Label(parent, text="Gripper:")
        label.grid(row=row, column=0, sticky=tk.W, pady=5)
        
        # Value display with state
        self.value_labels['gripper'] = ttk.Label(parent, text="Open")
        self.value_labels['gripper'].grid(row=row, column=2, sticky=tk.E, padx=(10, 0), pady=5)
        
        # Slider variable
        self.slider_vars['gripper'] = tk.DoubleVar(value=0.1)
        
        # Slider
        self.sliders['gripper'] = ttk.Scale(
            parent, 
            from_=self.gripper_limits[0], 
            to=self.gripper_limits[1], 
            variable=self.slider_vars['gripper'],
            orient=tk.HORIZONTAL,
            command=lambda val: self.on_gripper_move(val)
        )
        self.sliders['gripper'].grid(row=row, column=1, sticky=(tk.W, tk.E), pady=5)
        
    def on_slider_move(self, value, joint_name):
        """Update value label AND send command to QArm immediately"""
        deg_value = float(value)
        self.value_labels[joint_name].config(text=f"{deg_value:.1f}°")
        
        # Send command to QArm
        self.send_current_position()
        
    def on_gripper_move(self, value):
        """Update gripper display AND send command immediately"""
        gripper_value = float(value)
        state = "Closed" if gripper_value > 0.5 else "Open"
        self.value_labels['gripper'].config(text=state)
        
        # Send command to QArm
        self.send_current_position()
        
    def send_current_position(self):
        """Send current slider positions to QArm"""
        try:
            # Get all current values and convert to radians
            base_rad = self.degrees_to_radians(self.slider_vars['base'].get())
            shoulder_rad = self.degrees_to_radians(self.slider_vars['shoulder'].get())
            elbow_rad = self.degrees_to_radians(self.slider_vars['elbow'].get())
            wrist_rad = self.degrees_to_radians(self.slider_vars['wrist'].get())
            gripper_val = self.slider_vars['gripper'].get()
            
            # Create command arrays
            phiCMD = np.array([base_rad, shoulder_rad, elbow_rad, wrist_rad], dtype=np.float64)
            gprCMD = np.array([gripper_val], dtype=np.float64)
            
            # Send to QArm
            self.qarm.write_position(phiCMD, gprCMD)
            
            # Update current joints
            self.current_joints = phiCMD
            self.current_gripper = gprCMD
            
            self.status_label.config(text="Position updated", foreground="green")
            
        except Exception as e:
            self.status_label.config(text=f"Error: {str(e)}", foreground="red")
        
    def degrees_to_radians(self, degrees):
        """Convert degrees to radians"""
        return degrees * np.pi / 180.0
        
    def radians_to_degrees(self, radians):
        """Convert radians to degrees"""
        return radians * 180.0 / np.pi
        
    def home_position(self):
        """Move arm to home position (all joints at 0 degrees)"""
        try:
            # Set all sliders to 0
            for joint_name in ['base', 'shoulder', 'elbow', 'wrist']:
                self.slider_vars[joint_name].set(0.0)
                self.value_labels[joint_name].config(text="0.0°")
            
            # Set gripper to open
            self.slider_vars['gripper'].set(0.1)
            self.value_labels['gripper'].config(text="Open")
            
            # Send command to QArm
            phiCMD = np.array([0.0, 0.0, 0.0, 0.0], dtype=np.float64)
            gprCMD = np.array([0.1], dtype=np.float64)
            self.qarm.write_position(phiCMD, gprCMD)
            
            # Update current joints
            self.current_joints = phiCMD
            self.current_gripper = gprCMD
            
            self.status_label.config(text="Moved to home position", foreground="green")
            
        except Exception as e:
            self.status_label.config(text=f"Error: {str(e)}", foreground="red")
            
    def read_current_position(self):
        """Read the current position from the QArm and update sliders"""
        try:
            # Read current position from QArm
            self.qarm.read_std()
            
            # Get joint positions (they are stored in radians in measJointPosition)
            current_positions = self.qarm.measJointPosition
            
            # Update sliders with current position (convert radians to degrees for joints)
            joint_names = ['base', 'shoulder', 'elbow', 'wrist']
            for i, joint_name in enumerate(joint_names):
                deg_value = self.radians_to_degrees(current_positions[i])
                self.slider_vars[joint_name].set(deg_value)
                self.value_labels[joint_name].config(text=f"{deg_value:.1f}°")
            
            # Update gripper
            gripper_value = current_positions[4]
            self.slider_vars['gripper'].set(gripper_value)
            self.value_labels['gripper'].config(text="Closed" if gripper_value > 0.5 else "Open")
            
            self.status_label.config(text="Current position read", foreground="green")
            
        except Exception as e:
            self.status_label.config(text=f"Error reading position: {str(e)}", foreground="red")
            
    def run(self):
        """Start the GUI main loop"""
        try:
            # Move to home position initially
            self.home_position()
            self.root.mainloop()
        finally:
            # Clean up
            self.cleanup()
            
    def cleanup(self):
        """Clean up resources"""
        try:
            self.qarm.terminate()
        except:
            pass

def main():
    """Main function to run the QArm GUI"""
    app = QArmGUI()
    app.run()

if __name__ == "__main__":
    main()