class Student {
    constructor(name, age) {
      this.name = name;
      this.age = age;
    }
  
    printDetails() {
      console.log(`Name: ${this.name}, Age: ${this.age}`);
    }
  }
  

  class RegularStudent extends Student {
    constructor(name, age, grade) {
      super(name, age); 
      this.grade = grade;
    }
  
    getGrade() {
      return this.grade;
    }
  }
  

  let regularStudent = new RegularStudent('Alice', 16, 85);
  
  regularStudent.printDetails();
  
  console.log(`Grade: ${regularStudent.getGrade()}`); 
  