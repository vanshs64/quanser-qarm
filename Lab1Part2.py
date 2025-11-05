'''
Student gets transformation matrix between frames in pre-lab
- use given equations to convert pixel location in image to object's position in the sensor plane
- find object position in sensor, camera and robot frames
- change posX and posY in provided code

1. Arm moves above object
    - use iKin to find joint angles using posX, posY and 300mm as z
    - write position to robot with joint angles
2. Arm moves down to object
    - use iKin to find joint angles using posX, posY and 100mm as z
    - write position to robot with joint angles
3. Arm closes gripper
    - write to the gripper to close
4. Arm moves up
    - same as 1
5. Arm moves to home position
    - write 0 to all joints
6. Arm moves above object
    - same as 1
7. Arm moves down to object
    - same as 2
8. Arm opens gripper
    - write to gripper to open
9. Arm moves above object
    - same as 2
10. Arm moves to home position
    - same as 5
'''

import numpy as np
from Libraries.hal.products.qarm import QArmUtilities
from Libraries.pal.products.qarm import QArm
import time

def promptExit(waitForInput):
    if (waitForInput):
        inp = input("Type exit (not case sensitive) to exit, anything else to continue: ")
        if inp.lower() == "exit":
            return True

def moveToPickup(posX, posY, qArm, qArmUtil):
    posAbove = np.array([posX, posY, .3])
    posObject = np.array([posX, posY, .05])
    home = np.zeros(3)
    gamma = 0
    phi_prev = np.zeros((4, 4), dtype=np.float64) #0s are temporary idk how to read default values

    sleepTime = 2
    waitForInput = False

    print("Homing")
    phiCMD = qArmUtil.qarm_inverse_kinematics(home, gamma, phi_prev)[1]
    gprCMD = np.array(0.1)
    qArm.write_position(phiCMD, gprCMD)
    phi_prev = phiCMD
    time.sleep(sleepTime)
    if promptExit(waitForInput): qArm.terminate()

    print("1. Arm moves above object")
    phiCMD = qArmUtil.qarm_inverse_kinematics(posAbove, gamma, phi_prev)[1]
    gprCMD = np.array(0.1)
    qArm.write_position(phiCMD, gprCMD)
    phi_prev = phiCMD
    time.sleep(sleepTime)
    if promptExit(waitForInput): qArm.terminate()

    print("2. Arm moves down to object")
    phiCMD = qArmUtil.qarm_inverse_kinematics(posObject, gamma, phi_prev)[1]
    qArm.write_position(phiCMD, gprCMD)
    time.sleep(sleepTime)
    if promptExit(waitForInput): qArm.terminate()

    print("3. Arm closes gripper")
    gprCMD = np.array(0.9)
    qArm.write_position(phiCMD, gprCMD)
    time.sleep(sleepTime)
    if promptExit(waitForInput): qArm.terminate()

    print("4. Arm moves up")
    phiCMD = qArmUtil.qarm_inverse_kinematics(posAbove, gamma, phi_prev)[1]
    qArm.write_position(phiCMD, gprCMD)
    time.sleep(sleepTime)
    if promptExit(waitForInput): qArm.terminate()

    print("5. Arm moves to home position")
    phiCMD = qArmUtil.qarm_inverse_kinematics(home, gamma, phi_prev)[1]
    qArm.write_position(phiCMD, gprCMD)
    time.sleep(sleepTime)
    if promptExit(waitForInput): qArm.terminate()

    print("6. Arm moves above object")
    phiCMD = qArmUtil.qarm_inverse_kinematics(posAbove, gamma, phi_prev)[1]
    qArm.write_position(phiCMD, gprCMD)
    time.sleep(sleepTime)
    if promptExit(waitForInput): qArm.terminate()

    print("7. Arm moves down to object")
    phiCMD = qArmUtil.qarm_inverse_kinematics(posObject, gamma, phi_prev)[1]
    qArm.write_position(phiCMD, gprCMD)
    time.sleep(sleepTime)
    if promptExit(waitForInput): qArm.terminate()

    print("8. Arm opens gripper")
    gprCMD = np.array(0.1)
    qArm.write_position(phiCMD, gprCMD)
    time.sleep(sleepTime)
    if promptExit(waitForInput): qArm.terminate()

    print("9. Arm moves above object")
    phiCMD = qArmUtil.qarm_inverse_kinematics(posAbove, gamma, phi_prev)[1]
    qArm.write_position(phiCMD, gprCMD)
    time.sleep(sleepTime)
    if promptExit(waitForInput): qArm.terminate()

    print("10. Arm moves to home position")
    phiCMD = qArmUtil.qarm_inverse_kinematics(home, gamma, phi_prev)[1]
    qArm.write_position(phiCMD, gprCMD)
    time.sleep(sleepTime)
    if promptExit(waitForInput): qArm.terminate()

def moveToPickupAlt(posX, posY, qArm, qArmUtil):
    posAbove = np.array([posX, posY, .3])
    posObject = np.array([posX, posY, .05])

    posAboveAlt = np.array([posX, -posY, .3])
    posObjectAlt = np.array([posX, -posY, .05])

    home = np.zeros(3)
    gamma = 0
    phi_prev = np.zeros((4, 4), dtype=np.float64) #0s are temporary idk how to read default values

    sleepTime = 2
    waitForInput = False

    print("Homing")
    phiCMD = qArmUtil.qarm_inverse_kinematics(home, gamma, phi_prev)[1]
    gprCMD = np.array(0.1)
    qArm.write_position(phiCMD, gprCMD)
    phi_prev = phiCMD
    time.sleep(sleepTime)
    if promptExit(waitForInput): qArm.terminate()

    print("1. Arm moves above object")
    phiCMD = qArmUtil.qarm_inverse_kinematics(posAbove, gamma, phi_prev)[1]
    gprCMD = np.array(0.1)
    qArm.write_position(phiCMD, gprCMD)
    phi_prev = phiCMD
    time.sleep(sleepTime)
    if promptExit(waitForInput): qArm.terminate()

    print("2. Arm moves down to object")
    phiCMD = qArmUtil.qarm_inverse_kinematics(posObject, gamma, phi_prev)[1]
    qArm.write_position(phiCMD, gprCMD)
    time.sleep(sleepTime)
    if promptExit(waitForInput): qArm.terminate()

    print("3. Arm closes gripper")
    gprCMD = np.array(0.9)
    qArm.write_position(phiCMD, gprCMD)
    time.sleep(sleepTime)
    if promptExit(waitForInput): qArm.terminate()

    print("4. Arm moves up")
    phiCMD = qArmUtil.qarm_inverse_kinematics(posAbove, gamma, phi_prev)[1]
    qArm.write_position(phiCMD, gprCMD)
    time.sleep(sleepTime)
    if promptExit(waitForInput): qArm.terminate()

    print("5. Arm moves to home position")
    phiCMD = qArmUtil.qarm_inverse_kinematics(home, gamma, phi_prev)[1]
    qArm.write_position(phiCMD, gprCMD)
    time.sleep(sleepTime)
    if promptExit(waitForInput): qArm.terminate()

    print("6. Arm moves above object")
    phiCMD = qArmUtil.qarm_inverse_kinematics(posAboveAlt, gamma, phi_prev)[1]
    qArm.write_position(phiCMD, gprCMD)
    time.sleep(sleepTime)
    if promptExit(waitForInput): qArm.terminate()

    print("7. Arm moves down to object")
    phiCMD = qArmUtil.qarm_inverse_kinematics(posObjectAlt, gamma, phi_prev)[1]
    qArm.write_position(phiCMD, gprCMD)
    time.sleep(sleepTime)
    if promptExit(waitForInput): qArm.terminate()

    print("8. Arm opens gripper")
    gprCMD = np.array(0.1)
    qArm.write_position(phiCMD, gprCMD)
    time.sleep(sleepTime)
    if promptExit(waitForInput): qArm.terminate()

    print("9. Arm moves above object")
    phiCMD = qArmUtil.qarm_inverse_kinematics(posAboveAlt, gamma, phi_prev)[1]
    qArm.write_position(phiCMD, gprCMD)
    time.sleep(sleepTime)
    if promptExit(waitForInput): qArm.terminate()

    print("10. Arm moves to home position")
    phiCMD = qArmUtil.qarm_inverse_kinematics(home, gamma, phi_prev)[1]
    qArm.write_position(phiCMD, gprCMD)
    time.sleep(sleepTime)
    if promptExit(waitForInput): qArm.terminate()

#vvv CHANGE THESE vvv
posX = .6;
posY = -.2;
#^^^ END OF CHANGES ^^^

qArm = QArm()
qArmUtil = QArmUtilities()

moveToPickupAlt(posX,posY,qArm,qArmUtil)
moveToPickupAlt(posX,-posY,qArm,qArmUtil)


qArm.terminate()