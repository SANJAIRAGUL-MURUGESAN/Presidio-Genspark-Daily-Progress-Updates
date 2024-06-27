class Person:
  def __init__(self, name, age):  #method for initializing objects
    self.name = name
    self.age = age

  def greet(self):  # This is a method
    return f"Hello, my name is {self.name}!"  #Returns a string using f-string

# Create an object 
person1 = Person("Alice", 30)

# Call the greet() method on the person1 object
greeting = person1.greet()
print(greeting)  
