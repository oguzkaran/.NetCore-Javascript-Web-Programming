import {createRandomPoint} from "./csdpoint.mjs";

const createRandomPoints = (n, min, bound) => {
    let points = []

    while (n--)
        points.push(createRandomPoint(min, bound))

    return points;
}



export {createRandomPoints}

