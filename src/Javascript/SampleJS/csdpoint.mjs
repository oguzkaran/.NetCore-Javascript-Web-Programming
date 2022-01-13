import {randomInt, randomDouble} from "./csdrandomutil.mjs";

const Point = function (x, y) {
    this.x = x
    this.y = y
    this.toString = function () {
         return `(${this.x}, ${this.y})`
    }
}

const createPoint = (x, y) => new Point(x, y)
const createRandomPoint = (min, bound) => createPoint(randomDouble(min, bound), randomDouble(min, bound))
const createRandomIntPoint = (min, max) => createPoint(randomInt(min, max), randomInt(min, max))
const getOrigin = () => createPoint(0, 0)
export {Point,  createPoint, createRandomPoint, createRandomIntPoint, getOrigin}
