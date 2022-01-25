class Random {
    static nextNumber(min, max) //[min, max)
    {
        return Math.random() * (max - min) + min
    }

    static nextInt(min, max) //[min, max)
    {
        return parseInt(Random.nextNumber(min, max))
    }

    static nextBoolean()
    {
        return Random.nextInt(0, 2) === 1
    }
}

export {Random}
