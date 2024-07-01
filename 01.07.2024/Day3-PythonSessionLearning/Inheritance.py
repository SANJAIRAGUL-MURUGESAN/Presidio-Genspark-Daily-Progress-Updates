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