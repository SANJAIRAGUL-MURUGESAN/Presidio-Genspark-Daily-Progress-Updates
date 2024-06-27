def print_star_pyramid(rows):

  # Loop for each row
  for i in range(1, rows + 1):
    # Print spaces before the stars for proper alignment
    print(" " * (rows - i), end="")
    # Print stars for the current row, using 2 * i - 1 to get the odd number of stars
    print("*" * (2 * i - 1))

num_rows = int(input("Enter the number of rows for the pyramid: "))

# Print the star pyramid
print_star_pyramid(num_rows)
