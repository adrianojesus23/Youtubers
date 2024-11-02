const persons = require('./PersonalOrigin')
 
let personCopy = {...persons()}

Object.assign({},persons())

JSON.parse(JSON.stringify(persons()))