import numpy as np
from Libraries.hal.products.qarm import QArmUtilities
from Libraries.pal.products.qarm import QArm
import time

#CHANGE THESE ARRAYS TO THE DESIRED JOINT ANGLES
A = np.array([])
B = np.array([])
C = np.array([])
D = np.array([])
E = np.array([])
F = np.array([])

home = np.zeros(4)
gamma = 0

QArm.write_position(A, np.array(0.1)) #Move to A and open the gripper
time.sleep(5)

QArm.write_position(B)
time.sleep(5)

QArm.write_position(np.array(0.9)) #close gripper
time.sleep(5)

QArm.write_position(C)
time.sleep(5)

QArm.write_position(D)
time.sleep(5)

QArm.write_position(E)
time.sleep(5)

QArm.write_position(F)
time.sleep(5)

QArm.write_position(np.array(0.9)) #open gripper
time.sleep(5)

QArm.write_position(E)
time.sleep(5)

QArm.write_position(home)
time.sleep(5)