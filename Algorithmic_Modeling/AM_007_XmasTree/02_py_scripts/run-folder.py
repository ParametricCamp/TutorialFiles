# Based on code from https://github.com/standupmaths/xmastree2020

import board
import neopixel
import time 
from csv import reader
import sys
import os

# helper function for chunking 
def chunks(lst, n):
    for i in range(0, len(lst), n):
        yield lst[i:i+n]
        

# Given a filename, returns the parsed light object
def getLights(csvFile):
    print("Parsing " + csvFile)
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
            
            lineNumber += 1

    #print("Finished Parsing file " + csvFile)
    
    return lightArray


# Given a light sequence, it plays it on the tree
def playLights(neop, lights):
    f = 0
    for frame in lights:
        # print("running frame " + str(f))
        LED = 0
        while LED < NUMBEROFLEDS:
            neop[LED] = frame[LED]
            LED += 1
        neop.show()
        f += 1


# sleep_time = 0.033 # approx 30fps 
sleep_time = 0.017  # approx 60fps
NUMBEROFLEDS = 500
LOOPS_PER_SEQUENCE = 5
if len(sys.argv) > 2:
    LOOPS_PER_SEQUENCE = int(sys.argv[2])
print("Sequences will loop " + str(LOOPS_PER_SEQUENCE) + " times")

# Init the neopixel
pixels = neopixel.NeoPixel(board.D18, NUMBEROFLEDS, auto_write=False)

# get foldername from CLI arguments
folder_path = sys.argv[1]

# load folder files
csv_files = os.listdir(folder_path)


# Parse all the sequences at the beginning (its a heavy process for the pi)
sequences = []
for file in csv_files:
    full_path = os.path.join(folder_path, file)
    if os.path.isfile(full_path):
        lights = getLights(full_path)
        sequences.append(lights)

# Play sequences in a loop
while True:
    id = 0
    for lights in sequences:
        print("Playing file " + csv_files[id])
        for i in range(0, LOOPS_PER_SEQUENCE):
            if i != (LOOPS_PER_SEQUENCE - 1):
                print("Loop " + str(i + 1) + " from " + str(LOOPS_PER_SEQUENCE), end='\r')
            else:
                print("Loop " + str(i + 1) + " from " + str(LOOPS_PER_SEQUENCE))
            playLights(pixels, lights)
        id += 1
