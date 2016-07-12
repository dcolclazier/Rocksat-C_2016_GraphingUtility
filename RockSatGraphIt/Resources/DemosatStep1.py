import numpy as np
import pylab
import mahotas as mh
import os
import os.path
import math
import sys

def newprint(message):
	print(message)
	sys.stdout.flush()
	


def main():
    #imageDir = "d:/sandbox"
    #outputDir = "d:/sandbox"
    #outputFilename = "test"
    #extension = ".JPG"
    #totalFileCount = 40
    #outputExtension = ".txt"

    imageDir = "d:/dcim"
    outputDir = "D:/Coding/RockSatGraphIt/RockSatGraphIt/bin/Debug/ScriptFiles"
    outputFilename = "Step1results.txt"
    extension = ".JPG"
    totalFileCount = 7071

    newprint("Beginning Demosat Test...")
    newprint("Calculating max pixel count and otsu threshold for each image")
    percentCompleteStep = 100.0 / totalFileCount
       	
    #i = 0
    percentComplete = 0
    
    filename = open(outputDir + "/" + outputFilename, 'w')
    filename.write("Images,Max Pixel,Threshold Value\n")
    
    for root, dirs, files in os.walk(imageDir + "/"):
        for file in files:
            if file.endswith(extension):
                
                pylab.gray()
                RICH = mh.imread(root + "/" + file)
                #i += 1
                
                ###BEGIN OF MODIFICATIONS FOR APPLICATION USE
                percentComplete += percentCompleteStep
                newprint((math.floor(percentComplete)))
                ###END OF MODIFICATIONS FOR APPLICATION USE
        
                T = mh.thresholding.otsu(RICH)
                if T > 0:
                        newprint("otsu > 0 tick")
                #T = mh.otsu(RICH)

                filename.write(str(file)+","+str(RICH.max())+","+str(T)+"\n")
    filename.close()
    
#============================================================

main()  
newprint(100)
#newprint("Step 1 complete!\n")

#print ("Goodbye and Good Luck!")
