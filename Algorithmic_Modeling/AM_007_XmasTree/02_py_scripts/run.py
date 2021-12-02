# Based on code from https://github.com/standupmaths/xmastree2020

import board
import neopixel
import time 
from csv import reader
import sys

# helper function for chunking 
def chunks(lst, n):
    for i in range(0, len(lst), n):
        yield lst[i:i+n]

# sleep_time = 0.033 # approx 30fps 
sleep_time = 0.017  # approx 60fps

NUMBEROFLEDS = 500
pixels = neopixel.NeoPixel(board.D18, NUMBEROFLEDS, auto_write=False)

csvFile = sys.argv[1]


# read the file
# iterate through the entire thing and make all the points the same colour 
lightArray = []


with open(csvFile, 'r') as read_obj:
    # pass the file object to reader() to get the reader object
    csv_reader = reader(read_obj)

    # Iterate over each row in the csv using reader object
    lineNumber = 0
    for row in csv_reader:
        # row variable is a list that represents a row in csv
        # break up the list of rgb values 
        # remove the first item
        if lineNumber > 0:
            parsed_row = []
            row.pop(0)
            chunked_list = list(chunks(row, 3))
            for element_num in range(len(chunked_list)):
                # this is a single light 
                r = float(chunked_list[element_num][0])
                g = float(chunked_list[element_num][1])
                b = float(chunked_list[element_num][2])
                light_val = (g, r, b)
                # turn that led on
                parsed_row.append(light_val)
            
            # append that line to lightArray 
            lightArray.append(parsed_row)
        # time.sleep(0.03)

        lineNumber += 1

print("Finished Parsing")



# run the code on the tree
while True:
    f = 0
    for frame in lightArray:
        print("running frame " + str(f))
        LED = 0
        while LED < NUMBEROFLEDS:
            pixels[LED] = frame[LED]
            LED += 1
        pixels.show()
    
        f += 1
#        time.sleep(sleep_time)
