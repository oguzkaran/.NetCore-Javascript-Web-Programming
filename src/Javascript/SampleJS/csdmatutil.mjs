import {randomInt} from "./csdrandomutil.mjs";

const Point = function (x, y) {
    this.x = x
    this.y = y
    this.toString = function () {
         return `(${this.x}, ${this.y})`
    }
}

const Complex = function (real, imag) {
    this.real = real
    this.imag = imag
    
}

const createPoint = (x, y) => new Point(x, y)
const createRandomPoint = (min, max) => createPoint(randomInt(min, max), randomInt(min, max))
const createComplex = (real, imag) => new Complex(real === undefined ? 0 : real, imag === undefined ? 0 : imag)
const getOrigin = () => createPoint(0, 0) //{return {x: 0, y: 0}}
export {Point, Complex, createPoint, createRandomPoint, createComplex, getOrigin}
