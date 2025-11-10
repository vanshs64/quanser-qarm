import numpy as np
from Libraries.hal.products.qarm import QArmUtilities
from Libraries.pal.products.qarm import QArm
import time
from Libraries.pal.utilities.vision import Camera3D

cam = Camera3D()
print("Camera Mode, ACTIVATE")

cam.read_depth()

input("Hit enter to terminate: ")
cam.terminate()
print("Camera Mode, DEACTIVATE")