# String Slicing
my_string = "Hello, World!"
print(my_string[0:5])  # Output: Hello

# Printing charcaters using indexing in string
print(my_string[7]) # Output: W

# String Concatenation
greeting = "Hello"
name = "Sanjai"
print(greeting + ", " + name + "!")  # Output: Hello, Alice!

#F-Strings for String Formatting
name = "Sanjai"  
age = 22
greeting = f"Hello, my name is {name} and I'm {age} years old."  
print(greeting)  

#Making all character as Uppercase
a = "sanjai"
print(a.upper())

#Making all character as Lowercase
a = "SANJAI"
print(a.lower())

#Removes unwanted chracters(Whitespaces aslo)(left and right corner only)
a = "!Hello, World!"
print(a.strip("!"))

#Replaces string characters,word aslo
a = "Hello, World!"
print(a.replace("Hello", "J"))

#String spilt
a = "Sanjai,Ragul"
print(a.split(","))

#Capitilize first upper charcater in a string
a = "Sanjai Ragul"
print(a.capitalize())

#Converts string into lower case
a = "PreSidIo"
print(a.casefold())

#Makes a string centered
a = "Sanjai Ragul Murugesan"
print(a.center(100))

#Returns the number of time a value is occurred
txt = "Sanjai Ragul Sanjai Ragul"
x = txt.count("Sanjai")
print(x)

#Returns true if the string ends with the value
txt = "Hello,World."
x = txt.endswith(".")
print(x)

#Sets the tab size
txt = "H\te\tl\tl\to"
x =  txt.expandtabs(2)
print(x)

#Returns the index value of first occured or -1
txt = "Hello, welcome to my world."
x = txt.find("welcome")
print(x)

#Returns the index value of first occured or raises exception
txt = "Hello, welcome to my world."
x = txt.index("welcome")
print(x)

#Checks string is alphanumeric or not
txt = "Sanjai12"
x = txt.isalnum()
print(x)

#Checks string is Alphabetic or not
txt = "CompanyX"
x = txt.isalpha()
print(x)

#Checks string is ascii or not
txt = "Company123"
x = txt.isascii()
print(x)

#Returns True if all characters in the string are decimals
txt = "1234"
x = txt.isdecimal()
print(x)

# Check if all the characters in the text are digits
txt = "50800"
x = txt.isdigit()
print(x)

# Check if all the characters in the text are digits
txt = "50800"
x = txt.isdigit()
print(x)

# Check if the string is a valid identifier
txt = "Demo"
x = txt.isidentifier()
print(x)

# Check if all the characters in the text are in lower case
txt = "hello world!"
x = txt.islower()
print(x)

# Check if all the characters in the text are numeric
txt = "565543"
x = txt.isnumeric()
print(x)

# Check if all the characters in the text are printable
txt = "Hello! Are you #1?"
x = txt.isprintable()
print(x)

# Check if all the characters in the text are whitespaces
txt = "   "
x = txt.isspace()
print(x)

# Check if each word start with an upper case letter
txt = "Hello, And Welcome To My World!"
x = txt.istitle()
print(x)

# Check if all the characters in the text are in upper case
txt = "THIS IS NOW!"
x = txt.isupper()
print(x)

# Join all items in a tuple into a string, using a hash character as separator
myTuple = ("John", "Peter", "Vicky")
x = "#".join(myTuple)
print(x)

# Lower case the string
txt = "Hello my FRIENDS"
x = txt.lower()
print(x)

# Remove spaces to the left of the string
txt = "     banana     "
x = txt.lstrip()
print("of all fruits", x, "is my favorite")

# Search for the word "bananas", and return a tuple with three elements
# 1 - everything before the "match"
# 2 - the "match"
# 3 - everything after the "match"
txt = "I could eat bananas all day"
x = txt.partition("bananas")
print(x)

# Where in the text is the last occurrence of the string "casa"?
txt = "Hi cars, hi cars."
x = txt.rindex("cars")
print(x)

# Remove any white spaces at the end of the string
txt = "     banana     "
x = txt.rstrip()
print("of all fruits", x, "is my favorite")

# Upper case the string
txt = "Hello my friends"
x = txt.upper()
print(x)



