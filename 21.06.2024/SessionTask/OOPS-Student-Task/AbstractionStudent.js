class Student {
    constructor(name, age, grade) {
      this.name = name;
      this.age = age;
      this.grade = grade;
      this.attendance = []; 
    }
  
    calculateGPA() {
      return this.grade / 10; 
    }
  
    markAttendance(status) {
      let today = new Date();
      let dateString = `${today.getFullYear()}-${today.getMonth() + 1}-${today.getDate()}`;
      this.attendance.push({ date: dateString, status: status });
    }
  
    getAttendanceSummary() {
      return this.attendance;
    }

    printDetails() {
      console.log(`Name: ${this.name}`);
      console.log(`Age: ${this.age}`);
      console.log(`Grade: ${this.grade}`);
    }
  }
  
  let student1 = new Student('Alice', 16, 85);
  student1.printDetails();
  console.log(`GPA: ${student1.calculateGPA()}`);
  
  student1.markAttendance('present');
  student1.markAttendance('absent');
  console.log('Attendance Summary:');
  console.log(student1.getAttendanceSummary());
  