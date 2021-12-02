import board
import neopixel
import time 
import sys

NUMBEROFLEDS = 500
pixels = neopixel.NeoPixel(board.D18, NUMBEROFLEDS)

ids = sys.argv[1:]

for id in ids:
    i = int(id)
    pixels[i] = (255,255,255)
    time.sleep(1)
    
print("Done")

