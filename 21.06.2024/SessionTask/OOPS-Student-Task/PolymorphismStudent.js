// Base class
class Student {
    constructor(name, grade) {
      this.name = name;
      this.grade = grade;
    }
  
    calculateGPA() {
      return this.grade / 10; 
    }
  
    printDetails() {
      console.log(`Name: ${this.name}, Grade: ${this.grade}`);
    }
  }
  

  class RegularStudent extends Student {
    constructor(name, grade) {
      super(name, grade);
    }
  
    // Override calculateGPA method for regular students(Grade 10)
    calculateGPA() {
      return this.grade / 10;
    }
  }
  
  class EveningStudent extends Student {
    constructor(name, grade) {
      super(name, grade);
    }
  
    // Override calculateGPA method for evening students(Grade 20)
    calculateGPA() {
      return this.grade / 20; 
    }
  }
  

  let student1 = new RegularStudent('Alice', 85);
  let student2 = new EveningStudent('Bob', 18);
  
  console.log(`Student 1 GPA: ${student1.calculateGPA()}`); 
  console.log(`Student 2 GPA: ${student2.calculateGPA()}`); 
  
  student1.printDetails(); 
  student2.printDetails();