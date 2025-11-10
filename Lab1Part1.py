import numpy as np
import numpy.linalg as npla

L_1 = 0.1400
L_2 = 0.3500
L_3 = 0.0500
L_4 = 0.2500
L_5 = 0.1500
BETA = np.arctan(L_3/L_2)

LAMBDA_1 = L_1
LAMBDA_2 = np.sqrt(L_2**2 + L_3**2)
LAMBDA_3 = L_4 + L_5

def forward_kinematics(phi):
    """ QUANSER_ARM_FPK v 1.0 - 30th August 2020

    REFERENCE:
    Chapter 3. Forward Kinematics
    Robot Dynamics and Control, Spong, Vidyasagar, 1989

    INPUTS:
    phi     : Alternate joint angles vector 4 x 1

    OUTPUTS:
    p4      : End-effector frame {4} position vector expressed in base frame {0}
    R04     : rotation matrix from end-effector frame {4} to base frame {0}"""

    # From phi space to theta space
    theta = phi.copy()
    theta[0] = phi[0]
    theta[1] = phi[1] + BETA - np.pi/2
    theta[2] = phi[2] - BETA
    theta[3] = phi[3]

    # Transformation matrices for all frames:

    # T{i-1}{i} = quanser_arm_DH(  a, alpha,  d,     theta )
    T01 = quanser_arm_DH(            0, -np.pi/2, LAMBDA_1,  theta[0] )
    T12 = quanser_arm_DH( LAMBDA_2,            0,        0,  theta[1] )
    T23 = quanser_arm_DH(            0, -np.pi/2,        0,  theta[2] )
    T34 = quanser_arm_DH(            0,        0, LAMBDA_3,  theta[3] )

    T02 = T01@T12
    T03 = T02@T23
    T04 = T03@T34

    # Position of end-effector Transformation

    # Extract the Position vector
    # p1   = T01(1:3,4);
    # p2   = T02(1:3,4);
    # p3   = T03(1:3,4);
    p4   = T04[0:3,3]

    # Extract the Rotation matrix
    # R01 = T01(1:3,1:3);
    # R02 = T02(1:3,1:3);
    # R03 = T03(1:3,1:3);
    R04 = T04[0:3,0:3]

    return p4, R04

def quanser_arm_DH(a, alpha, d, theta):

        """ QUANSER_ARM_DH
        v 1.0 - 26th March 2019

        REFERENCE:
        Chapter 3. Forward and Inverse Kinematics
        Robot Modeling and Control
        Spong, Hutchinson, Vidyasagar
        2006

        INPUTS:
        a       :   translation  : along : x_{i}   : from : z_{i-1} : to : z_{i}
        alpha   :      rotation  : about : x_{i}   : from : z_{i-1} : to : z_{i}
        d       :   translation  : along : z_{i-1} : from : x_{i-1} : to : x_{i}
        theta   :      rotation  : about : z_{i-1} : from : x_{i-1} : to : x_{i}
        (Standard DH Parameters are being used here)

        OUTPUTS:
        T       : transformation                   : from :     {i} : to : {i-1}"""

        # Rotation Transformation about z axis by theta
        T_R_z = np.array([[np.cos(theta), -np.sin(theta), 0, 0], [np.sin(theta), np.cos(theta), 0, 0], [0, 0, 1, 0], [0, 0, 0, 1]], dtype=np.float64)

        # Translation Transformation along z axis by d
        T_T_z = np.array([[1, 0, 0, 0], [0, 1, 0, 0], [0, 0, 1, d], [0, 0, 0, 1]], dtype=np.float64)

        # Translation Transformation along x axis by a
        T_T_x = np.array([[1, 0, 0, a], [0, 1, 0, 0], [0, 0, 1, 0], [0, 0, 0, 1]], dtype=np.float64)

        # Rotation Transformation about x axis by alpha
        T_R_x = np.array([[1, 0, 0, 0], [0, np.cos(alpha), -np.sin(alpha), 0], [0, np.sin(alpha), np.cos(alpha), 0], [0, 0, 0, 1]], dtype=np.float64)

        # For a transformation FROM frame {i} TO frame {i-1}: A
        T = T_R_z@T_T_z@T_T_x@T_R_x

        return T

phi = np.array([np.pi/4, np.pi/4, np.pi/4, np.pi/4])

result = forward_kinematics(phi)

pos = result[0]
rot = result[1]

print("End-Effector Position:\n", pos)
print("End-Effector Rotation:\n", rot)