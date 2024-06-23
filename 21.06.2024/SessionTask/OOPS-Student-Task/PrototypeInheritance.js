let student = {
    studentLearn: false,
};
let teacher = {
    teacherTeaches: true,
};
Object.setPrototypeOf(teacher, student);
console.log(teacher.teacherTeaches);
console.log(teacher.studentLearn);

const number = {
    a: 1,
    b: 2,
    __proto__: {
      b: 3,
      c: 4,
    },
  };

  console.log(number.a);
  console.log(number.b); 
  console.log(number.__proto__.b); // Property Shadowing
  console.log(number.d);



  const parent = {
    value: 2,
    method() {
      return this.value + 1;
    },
  };
  console.log(parent.method()); 
  
  const child = {
    __proto__: parent,
  };
  console.log(child.method()); 
  
  child.value = 4; 
  console.log(child.method()); 