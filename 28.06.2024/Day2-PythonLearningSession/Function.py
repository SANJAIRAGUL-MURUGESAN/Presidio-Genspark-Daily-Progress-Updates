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



