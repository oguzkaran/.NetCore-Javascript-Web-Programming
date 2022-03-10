/*
    Sınıf Çalışması: Aşağıda açıklanan RandomNumberEmitter sınıfının EventEmitter sınıfından türetecek biçimde yazınız
    Açıklamalar:
        - Sınıfın min, max, interval, count parametreli bir ctor'u olacaktır.
        - Sınıf her interval'da [min, max] aralığında rasgele sayı üretecektir. Toplam count kadar sayı üretilecektir
        - Sınıfın prime, odd ve even isimli 3 tane event'i olacaktır: Sayının durumuna uygun even emit edilecektir
        - Sayı asal ise hem primae hem de odd event'leri sırasıyla emit edilecektir
        - 2 sayısı için de yine prime event'i ve even event'i emit edilecektir
 */
import {RandomNumberEmitter} from '../../../csd-modules/csdrandomnumberemitter.mjs'
import {writeLine} from '../../../csd-modules/csdstdioutil.mjs'

function main()
{
    const rne = new RandomNumberEmitter(1, 50, 1000, 10)

    rne.start()
    rne.on("value", val => writeLine(val))
    rne.on("prime", p => writeLine(`prime:${p}`))
    rne.on("even", p => writeLine(`even:${p}`))
    rne.on("odd", p => writeLine(`odd:${p}`))
}


main()
