class Student {
    constructor(name, age, grade) {
      // Private properties because _propertyname indicates that they are intended to be private
      this._name = name;
      this._age = age;
      this._grade = grade;
      this._attendance = []; 
    }

    markAttendance(status) {
      let today = new Date();
      let dateString = `${today.getFullYear()}-${today.getMonth() + 1}-${today.getDate()}`;
      this._attendance.push({ date: dateString, status: status });
    }

    getAttendance() {
      return this._attendance;
    }
  
    printDetails() {
      console.log(`Name: ${this._name}`);
      console.log(`Age: ${this._age}`);
      console.log(`Grade: ${this._grade}`);
    }
  }
  
  let student1 = new Student('Alice', 16, 85);
  
  student1.markAttendance('present');
  student1.markAttendance('absent');
  console.log('Attendance:', student1.getAttendance());
  
  student1.printDetails();
  