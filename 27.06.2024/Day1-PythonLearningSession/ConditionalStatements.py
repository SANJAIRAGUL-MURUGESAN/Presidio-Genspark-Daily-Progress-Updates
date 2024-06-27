#if else
age = 18
if age >= 18:
  print("You are eligible to vote.")
else:
  print("You are not eligible to vote.")

#if elif else
score = 85
if score >= 90:
  print("Grade: A")
elif score >= 80:
  print("Grade: B")
elif score >= 70:
  print("Grade: C")
else:
  print("Grade: D or F")

#Ternary
is_adult = True if age >= 18 else False
print(is_adult)  # Output: True

