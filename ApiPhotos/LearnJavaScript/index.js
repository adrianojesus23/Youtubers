var globalVar = 5;

let fruits = [0,1,2,3,4,5];




// Using setTimeout to log fruits with increasing delay
for (let i = 0; i < fruits.length; i++) {
   let setTimeOutId = setInterval(() => console.table(fruits), i * 1000); // Each iteration delayed by 1 second
  clearInterval(setTimeOutId)
}
