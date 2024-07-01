# "r" - Read - Default value. Opens a file for reading, error if the file does not exist
# "a" - Append - Opens a file for appending, creates the file if it does not exist
# "w" - Write - Opens a file for writing, creates the file if it does not exist
# "x" - Create - Creates the specified file, returns an error if the file exists

#To open and read a text file
f = open("demofile.txt", "rt")
print(f.read())

#To open and read the first five characters of a text file
f1 = open("demofile.txt", "rt")
print(f1.read(5))

#To open and read a line in file
f = open("demofile.txt", "r")
print(f.readline())

#To open and read line by line in file
f = open("demofile.txt", "r")
for x in f:
  print(x)

#closing a opened file
f = open("demofile.txt", "r")
print(f.readline())
f.close()

#-------------------File Writing--------------------------
#opening a file and appending content in a file
f = open("demofile2.txt", "a")
f.write("This is demofile2 text!")
f.close()

#open and read the file after the appending:
f = open("demofile2.txt", "r")
print(f.read())

#open and rewrite the file after the appending:
f = open("demofile2.txt", "w")
f.write("Woops! I have deleted the content!")
f.close()

#open and read the file after the overwriting:
f = open("demofile2.txt", "r")
print(f.read())