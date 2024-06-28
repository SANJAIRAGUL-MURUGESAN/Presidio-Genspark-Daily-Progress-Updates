-----------------------Python_StringManipulation------------------------------

Resource : https://www.w3schools.com/python/python_strings_methods.asp

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

-----------------------------Python_Functions---------------------------

Resource : https://www.w3schools.com/python/python_functions.asp

# Creating and calling a function
def my_function():
  print("Hi! This is Sanjai from Presidio Solutions")
my_function()

# Creating and calling a function with arguments
def my_function(fname):
  print(f"My Name : {fname}")
my_function("Sanjai")

# Creating and calling a function with one or more arguments
def my_function(fname, lname):
  print(fname + " " + lname)
my_function("Sanjai","Ragul")

# Creating and calling a function when number of arguments is unknown
def my_function(*kids):
  print("The youngest child is " + kids[2])
my_function("child1", "child2", "child3")

# Creating and calling a function with keywords
def my_function(child3, child2, child1):
  print("The youngest child is " + child3)
my_function(child1 = "child1", child2 = "child2", child3 = "child3")

# Creating and calling a function with number of keywords is unknown
def my_function(**kid):
  print("His last name is " + kid["lname"])
my_function(fname = "Sanjai", lname = "Ragul")

#Default Parameter value
def my_function(country = "Norway"):
  print("I am from " + country)
my_function("India")

#Passing list to a function
def my_function(food):
  for x in food:
    print(x)
fruits = ["apple", "banana", "cherry"]
my_function(fruits)

#function Returning
def my_function(x):
  return 5 * x
print(my_function(3))



------------------------Python_Tuples-------------------------------

https://www.w3schools.com/python/python_tuples.asp

# Tuples are used to store multiple items in a single variable.
# Tuple items are ordered, unchangeable, and allow duplicate values.
# Tuples are unchangeable, meaning that we cannot change, add or remove items after the tuple has been created.

thistuple = ("apple", "banana", "cherry", "apple", "cherry")
print(thistuple)
tuple1 = ("abc", 34, True, 40, "male")
print(tuple1)

#Accessing Tuple
thistuple = ("apple", "banana", "cherry")
print(thistuple[1])

#Negative Indexing so from last
thistuple = ("apple", "banana", "cherry")
print(thistuple[-1])

#Accessing with Range (First value included and second values excluded)
thistuple = ("apple", "banana", "cherry", "orange", "kiwi", "melon", "mango")
print(thistuple[2:5])

#To change tuple values (Convert tuple to list and change and again convert to tuple)
x = ("apple", "banana", "cherry")
y = list(x)
y[1] = "kiwi"
x = tuple(y)
print(x)

#To add Items in tuple (Convert tuple to list and add and again convert to tuple)
thistuple = ("apple", "banana", "cherry")
y = list(thistuple)
y.append("orange")
thistuple = tuple(y)

#Adding tuple to a tuple
thistuple = ("apple", "banana", "cherry")
y = ("orange",)
thistuple += y
print(thistuple)

#Removing tuple values (Convert tuple to list and add and again convert to tuple)
thistuple = ("apple", "banana", "cherry")
y = list(thistuple)
y.remove("apple")
thistuple = tuple(y)

#Deleting complete tuple
thistuple = ("apple", "banana", "cherry")
del thistuple


-----------------------------Python_Sets----------------------------------------

https://www.w3schools.com/python/python_sets.asp

# Sets are used to store multiple items in a single variable.
# A set is a collection which is unordered, unchangeable*, and unindexed.

#Creating and Printing Sets
thisset = {"apple", "banana", "cherry"}
print(thisset)

#Accessing set
thisset = {"apple", "banana", "cherry"}
for x in thisset:
  print(x)

#Checks for certain value
thisset = {"apple", "banana", "cherry"}
print("banana" in thisset)

#Adding valus in Set
thisset = {"apple", "banana", "cherry"}
thisset.add("orange")
print(thisset)

#Adding values in one set to other set
thisset = {"apple", "banana", "cherry"}
tropical = {"pineapple", "mango", "papaya"}
thisset.update(tropical)
print(thisset)

#Removing Set Items - If element does not exist, it will raise a error
thisset = {"apple", "banana", "cherry"}
thisset.remove("banana")
print(thisset)

#Removing Set Items - If element does not exist, it will not araise a error
thisset = {"apple", "banana", "cherry"}
thisset.discard("banana")
print(thisset)

#pop() - removes random item
thisset = {"apple", "banana", "cherry"}
x = thisset.pop()
print(x)
print(thisset)

# To Clears method emties the set
thisset = {"apple", "banana", "cherry"}
thisset.clear()
print(thisset)

# To Delete the set
thisset = {"apple", "banana", "cherry"}
del thisset
print(thisset)

#Set Looping
thisset = {"apple", "banana", "cherry"}
for x in thisset:
  print(x)

#Set Union
set1 = {"a", "b", "c"}
set2 = {1, 2, 3}
set3 = set1.union(set2)
print(set3)

#Joins multiple set
set1 = {"a", "b", "c"}
set2 = {1, 2, 3}
set3 = {"John", "Elena"}
set4 = {"apple", "bananas", "cherry"}
myset = set1.union(set2, set3, set4)
print(myset)

#set intersection
set1 = {"apple", "banana", "cherry"}
set2 = {"google", "microsoft", "apple"}
set3 = set1.intersection(set2)
print(set3)

#set difference
set1 = {"apple", "banana", "cherry"}
set2 = {"google", "microsoft", "apple"}
set3 = set1.difference(set2)
print(set3)

#set symmetric difference
set1 = {"apple", "banana", "cherry"}
set2 = {"google", "microsoft", "apple"}
set3 = set1.symmetric_difference(set2)
print(set3)


----------------------------Python_Dictionary----------------------

Resource : https://www.w3schools.com/python/python_dictionaries.asp

# Dictionaries are used to store data values in key:value pairs.
# A dictionary is a collection which is ordered*, changeable and do not allow duplicates.
# Dictionaries cannot have two items with the same key:

#Creating and Printing Dictionary
thisdict = {
  "brand": "Ford",
  "model": "Mustang",
  "year": 1964
}
print(thisdict)

#Creating and Printing Dictionary using key value Pair
thisdict = {
  "brand": "Ford",
  "model": "Mustang",
  "year": 1964
}
print(thisdict["brand"])

#Duplicates will overwrite existing values(keys)
thisdict = {
  "brand": "Ford",
  "model": "Mustang",
  "year": 1964,
  "year": 2020
}
print(thisdict)

#Values in Dictionary can be of any type
thisdict = {
  "brand": "Ford",
  "electric": False,
  "year": 1964,
  "colors": ["red", "white", "blue"]
}
print(thisdict)

#Accessing Dictionary(values)(Method1)
thisdict = {
  "brand": "Ford",
  "model": "Mustang",
  "year": 1964
}
x = thisdict["model"]
print(x)

#Accessing Dictionary(values)(Method2)
thisdict = {
  "brand": "Ford",
  "model": "Mustang",
  "year": 1964
}
x = thisdict.get("model")
print(x)

#Printing Keys in a dictionary
thisdict = {
  "brand": "Ford",
  "model": "Mustang",
  "year": 1964
}
x = thisdict.keys()
print(x)

#Printing Keys in a dictionary - Add a new item to the original dictionary,
car = {
"brand": "Ford",
"model": "Mustang",
"year": 1964
}
x = car.keys()
print(x) #before the change
car["color"] = "white"
print(x) #after the change

#Printing Values in a dictionary
thisdict = {
  "brand": "Ford",
  "model": "Mustang",
  "year": 1964
}
x = thisdict.values()

#Accessing car values and changing
car = {
"brand": "Ford",
"model": "Mustang",
"year": 1964
}
x = car.values()
print(x) #before the change
car["year"] = 2020
print(x) #after the change

#Accessing item-values and changing
car = {
"brand": "Ford",
"model": "Mustang",
"year": 1964
}
x = car.items()
print(x) #before the change
car["year"] = 2020
print(x) #after the change