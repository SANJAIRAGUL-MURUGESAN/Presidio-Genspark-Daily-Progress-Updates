def get_digits(card_number):
    # Convert the card number to a string
    card_number_str = str(card_number)
    
    # Reverse the string manually
    reversed_card_number_str = ''.join(card_number_str[::-1])
    
    # Convert each character in the reversed string to an integer
    digits = []
    for char in reversed_card_number_str:
        digits.append(int(char))
    
    return digits

def double_every_second_digit(digits):
    doubled_digits = []
    for i, digit in enumerate(digits):
        if i % 2 == 1:  # Check if the index i is odd (every second digit)
            doubled_digits.append(digit * 2)
        else:
            doubled_digits.append(digit)
    return doubled_digits

def luhn_check(card_number):
    
    # Reverse the card number and convert it to a list of integers
    digits = get_digits(card_number)
    
    # Double every second digit
    doubled_digits = double_every_second_digit(digits)
    
    # Subtract 9 from digits greater than 9
    subtracted_digits = [digit - 9 if digit > 9 else digit for digit in doubled_digits]
    
    # Sum all digits
    sum_digits = sum(subtracted_digits)
    
    # Check if the sum is divisible by 10
    return sum_digits % 10 == 0

# Example usage:
card_number = "4556737586899855"  # Replace with any credit card number, Invalid=1234567890123456"
is_valid = luhn_check(card_number)

if is_valid:
    print(f"The credit card number {card_number} is valid.")
else:
    print(f"The credit card number {card_number} is not valid.")
