# SA-University-Management
A C# program that manages and displays information about universities in South Africa. It allows users to input university details, store them in a text file, and display the data with special formatting based on conditions like the oldest university, university with the highest student population, and cities with multiple universities

## Features

- **Add University Information:** 
  - University Name
  - Year Established
  - City Situated In
  - Number of Students
- **Store University Information:** Information is stored in a text file (`University.txt`) with each field separated by a hashtag (`#`).
- **Display University Information:**
  - If a university is the **oldest**, it is marked with a single asterisk (`*`).
  - If a university has the **highest number of students**, it is marked with two asterisks (`**`).
  - If a **city has more than one university**, the records of all universities in that city are marked with three asterisks (`***`).

## Example Output

```plaintext
University of Cape Town#1829#Cape Town#29000*  
University of Pretoria#1908#Pretoria#53000  
University of Johannesburg#2005#Johannesburg#50000  
University of Witwatersrand#1896#Johannesburg#40000***  
University of Free State#1904#Bloemfontein#31000
```

# How to Run
  1. Clone the repository or download the source code.
  2. Ensure you have Python 3 installed on your machine.
  3. Open a terminal in the project directory.
  4. Run the program using the following command
