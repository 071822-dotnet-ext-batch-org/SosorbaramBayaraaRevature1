import { MyClass } from './NewFile';

console.log('hell ya!');
let myClass1 = new MyClass('omg!',
(a: string) => {
    return `this ${a} is betten than our kingdom`
});

console.log(myClass1.name, myClass1.sound('pair of warthog'))