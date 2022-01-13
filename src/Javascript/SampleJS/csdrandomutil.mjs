const randomInt = (min, max) => parseInt(Math.random() * (max - min + 1)) + min
const randomBoolean = () => randomInt(0, 1) === 1

export {randomInt, randomBoolean}
