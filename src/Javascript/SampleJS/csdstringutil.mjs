import {randomInt} from "./csdrandomutil.mjs";

function randomText(n, text)
{
    let str = ""
    let len = text.length;

    for (let i = 0; i < n; ++i)
        str += text.charAt(randomInt(0, len))

    return str
}

function randomTextTR(n)
{
    return randomText(n, "ABCÇDEFGĞHIİJKLMNOÖPRSŞTUÜVYZabcçdefgğhıijklmnoöprsştuüvyz")
}


function randomTextsTR(n, min, max)
{
    let result = [];

    while (n--)
        result.push(randomTextTR(randomInt(min, max)))

    return result
}


function randomTextEN(n)
{
    return randomText(n, "ABCDEFGHIJKLMNOPQRSTUWXVYZabcdefghijklmnopqrstuwxvyz")
}

function randomTextsEN(n, min, max)
{
    let result = [];

    while (n--)
        result.push(randomTextEN(randomInt(min, max)))

    return result
}

export {randomText, randomTextTR, randomTextEN, randomTextsEN, randomTextsTR}
