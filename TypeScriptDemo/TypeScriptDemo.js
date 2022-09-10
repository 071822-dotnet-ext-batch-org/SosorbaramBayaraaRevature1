import { MyClass } from './NewFile';
console.log('hell ya!');
var myClass1 = new MyClass('omg!', function (a) {
    return "this ".concat(a, " is betten than our kingdom");
});
console.log(myClass1.name, myClass1.sound('pair of warthog'));
