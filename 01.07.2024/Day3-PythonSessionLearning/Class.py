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