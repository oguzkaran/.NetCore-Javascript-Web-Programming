const isLeap = year => year % 4 === 0 && year % 100 !== 0 || year % 400 === 0


process.stdout.write(`${typeof isLeap}\n`)

for (let y = 2000; y <= 2104; ++y)
    if (isLeap(y))
        process.stdout.write(`${y} `)

