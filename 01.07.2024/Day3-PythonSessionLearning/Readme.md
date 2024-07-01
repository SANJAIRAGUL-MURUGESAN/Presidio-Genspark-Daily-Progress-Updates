--------------------------Python Class Learning---------------------------

Resource Link : https://www.w3schools.com/python/python_classes.asp

#Basic Structure
class MyClass:
  x = 5
o1 = MyClass()
print(o1.x)
#---------------

# All classes have a function called __init__(), which is always executed when the class is being initiated.
# Use the __init__() function to assign values to object properties, or other operations that are necessary to do when the object is being created.
# The __init__() function is called automatically every time the class is being used to create a new object.
#Example2
class Person:
  def __init__(self, name, age):
    self.name = name
    self.age = age

p1 = Person("John", 36)

print(p1.name)
print(p1.age)
#-------------------------------

#Example3
class Person:
  def __init__(self, name, age):
    self.name = name
    self.age = age

  def __str__(self):
    return f"{self.name}(Age:{self.age})"

p1 = Person("John", 36)
print(p1)
#-----------------------------------------

# Objects can also contain methods. Methods in objects are functions that belong to the object.
#Example4
class Person:
  def __init__(self, name, age):
    self.name = name
    self.age = age

  def myfunc(self):
    print("Hello my name is " + self.name)

p1 = Person("John", 36)
p1.myfunc()
#-------------------------------------------

#Example5
# The self parameter is a reference to the current instance of the class, and is used to access variables that belong to the class.
# It does not have to be named self , we can call it whatever you like, but it has to be the first parameter of any function in the class
# modify properties on objects
class Person:
  def __init__(self, name, age):
    self.name = name
    self.age = age

  def myfunc(self):
    print(f"Hello my name is {self.name} and age {self.age}")

p1 = Person("John", 36)
p1.age = 40
p1.myfunc()

#delete properties on objects by using the del keyword
p2 = Person("Sanjai", 22)
del p2.age
#delete objects by using the del keyword:
del p2

---------------------------------------------------------------------------------------------------------

-------------------------------------Python - Inheritance------------------------------------------------

Resourde Linl : https://docs.python.org/3/tutorial/classes.html#inheritance
Resourde Linl : https://www.geeksforgeeks.org/what-is-hybrid-inheritance-in-python/?ref=ml_lbp

class Person:
  def __init__(self, fname, lname):
    self.firstname = fname
    self.lastname = lname

  def printname(self):
    print(self.firstname, self.lastname)

#UPerson class to create an object, and then execute the printname method:
x = Person("Sanjai", "Ragul")
x.printname()

#child class
# We want to add the __init__() function to the child class (instead of the pass keyword).
# The child's __init__() function overrides the inheritance of the parent's __init__() function.
# To keep the inheritance of the parent's __init__() function, add a call to the parent's __init__() function.
#Example alone: (so commented)
# class Student(Person):
#   def __init__(self, fname, lname):
    #Person.__init__(self, fname, lname) call to the parent's __init__() function:


# Python also has a super() function that will make the child class inherit all the methods and properties from its parent.
#Example alone: (so commented)
# class Student(Person):
#   def __init__(self, fname, lname):
#     super().__init__(fname, lname)


#Student class to create an object, and then execute the printname method in parent class
class Student(Person):
  def __init__(self, fname, lname, year):
    super().__init__(fname, lname)
    self.graduationyear = year
  def welcome(self):
    print("Welcome", self.firstname, self.lastname, "to the class of", self.graduationyear)

p = Student("Sanjai", "Ragul", 2024)
p.welcome()

#Single Inheritance

# Base class
class Parent:
    def func1(self):
        print("This function is in parent class.")
 
# Derived class
class Child(Parent):
    def func2(self):
        print("This function is in child class.")
 
# Priting code
object = Child()
object.func1()
object.func2()


# multiple inheritance
 
# Base class1
class Mother:
    mothername = ""
    def mother(self):
        print(self.mothername)
 
# Base class2
class Father:
    fathername = ""
    def father(self):
        print(self.fathername)
 
# Derived class
class Son(Mother, Father):
    def parents(self):
        print("Father :", self.fathername)
        print("Mother :", self.mothername)

# Priting code
s1 = Son()
s1.fathername = "RAM"
s1.mothername = "SITA"
s1.parents()

# multilevel inheritance
 
# Base class  
class Grandfather:
    def __init__(self, grandfathername):
        self.grandfathername = grandfathername
 
# Intermediate class
class Father(Grandfather):
    def __init__(self, fathername, grandfathername):
        self.fathername = fathername
        # invoking constructor of Grandfather class
        Grandfather.__init__(self, grandfathername)
 
# Derived class
class Son(Father):
    def __init__(self, sonname, fathername, grandfathername):
        self.sonname = sonname
        # invoking constructor of Father class
        Father.__init__(self, fathername, grandfathername)
 
    def print_name(self):
        print('Grandfather name :', self.grandfathername)
        print("Father name :", self.fathername)
        print("Son name :", self.sonname)
 
#  Priting code
s1 = Son('A', 'B', 'C')
print(s1.grandfathername)
s1.print_name()

# Hierarchical inheritance
 
# Base class
class Parent:
    def func1(self):
        print("This function is in parent class.")
 
# Derived class1  
class Child1(Parent):
    def func2(self):
        print("This function is in child 1.")
 
# Derivied class2
class Child2(Parent):
    def func3(self):
        print("This function is in child 2.")
 
# Priting code
object1 = Child1()
object2 = Child2()
object1.func1()
object1.func2()
object2.func1()
object2.func3()

#Hybrid Inheritance

class Animal:
    def speak(self):
        print("Animal speaks")

class Mammal(Animal):
    def give_birth(self):
        print("Mammal gives birth")

class Bird(Animal):
    def lay_eggs(self):
        print("Bird lays eggs")

class Platypus(Mammal, Bird):
    pass

platypus = Platypus()
platypus.speak()        # Method from Animal class
platypus.give_birth()   # Method from Mammal class
platypus.lay_eggs()     # Method from Bird class

---------------------------------------------------------------------------------------------------------

--------------------------------------Python - Polymorphism----------------------------------------------

Resource Link : https://www.w3schools.com/python/python_polymorphism.asp

class Car:
  def __init__(self, brand, model):
    self.brand = brand
    self.model = model

  def move(self):
    print("Drive!")

class Boat:
  def __init__(self, brand, model):
    self.brand = brand
    self.model = model

  def move(self):
    print("Sail!")

class Plane:
  def __init__(self, brand, model):
    self.brand = brand
    self.model = model

  def move(self):
    print("Fly!")

car1 = Car("Ford", "Mustang")       #Create a Car class
boat1 = Boat("Ibiza", "Touring 20") #Create a Boat class
plane1 = Plane("Boeing", "747")     #Create a Plane class

for x in (car1, boat1, plane1):
  x.move()

#Inheritance Class Polymorphism

class Vehicle:
  def __init__(self, brand, model):
    self.brand = brand
    self.model = model

  def move(self):
    print("Move!")

class Car(Vehicle):
  pass

class Boat(Vehicle):
  def move(self):
    print("Sail!")

class Plane(Vehicle):
  def move(self):
    print("Fly!")

car1 = Car("Ford", "Mustang") #Create a Car object
boat1 = Boat("Ibiza", "Touring 20") #Create a Boat object
plane1 = Plane("Boeing", "747") #Create a Plane object

for x in (car1, boat1, plane1):
  print(x.brand)
  print(x.model)
  x.move()

---------------------------------------------------------------------------------------------------------

-------------------------------------------Python - Modules----------------------------------------------

Resource Link : https://www.w3schools.com/python/python_modules.asp

import MyModule as mx #user defined module
import platform  #built in Module
from MyModule import person1

#built in Module
x = platform.system()
print(x)

#imported user defined module
a = mx.person1["age"]
print(a)

---------------------------------------------------------------------------------------------------------

--------------------------------------------Python - FileHandling----------------------------------------

Resource Link : https://www.w3schools.com/python/python_file_handling.asp


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

---------------------------------------------------------------------------------------------------------

-------------------------------------Python - ExceptionHandling------------------------------------------

Resource Link : https://www.geeksforgeeks.org/python-exception-handling/

#Handling errors in general
a = [1, 2, 3]
try: 
    print ("Second element = %d" %(a[1]))
 
    print ("Fourth element = %d" %(a[3]))
 
except:
    print ("An error occurred")

#Handling Specific errors
def fun(a):
    if a < 4:
 
        b = a/(a-3)
    print("Value of b = ", b)
try:
    fun(3)
    fun(5)
except ZeroDivisionError:
    print("ZeroDivisionError Occurred and Handled")
except NameError:
    print("NameError Occurred and Handled")

#with else clause
def AbyB(a , b):
    try:
        c = ((a+b) / (a-b))
    except ZeroDivisionError:
        print ("a/b result in 0")
    else:
        print (c)
AbyB(2.0, 3.0)
AbyB(3.0, 3.0)


#Exception Handling with Finally
try:
    k = 5//0
    print(k)
 
except ZeroDivisionError:
    print("Can't divide by zero")
 
finally:
    print('This is always executed')


---------------------------------------------------------------------------------------------------------
