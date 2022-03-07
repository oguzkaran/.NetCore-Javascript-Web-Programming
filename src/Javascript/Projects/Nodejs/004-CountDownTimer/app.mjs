/*
* Sınıf Çalışması: Aşağıda açıklanan ve geri sayım işlemi yapan sınıfıayrı modüller içerisinde yazıp test ediniz:
* Açıklamalar:
*   - Sınıf milisaniye cinsinden toplam zamanı ve yine milisaniye cinsinden periyot bilgisini alacaktır
*   - Bu fonksiyon dışarıdan alınacaktır ve her periyotta kalan zaman ile çağrılacaktır
*   - Geri sayım işlemi sonunda finishedCallback isimli bir fonksiyon çağrılacaktır. Yine bu fonksiyon da
*   dışarıdan alınacaktır
*   - Sınıfı kullanan programcı bu foksiyonlaroı vermezse boş olarak çağrılacaklardır
*/


import {CountDownTimer} from '../../../csd-modules/csdcountdowntimer.mjs'
import {writeLine} from '../../../csd-modules/csdstdioutil.mjs'

function main()
{
    let cdt = new CountDownTimer(10000, 1000)

    cdt.start(ms => writeLine(ms / 1000), () => writeLine("Finished"))
    writeLine("main ands")
}

main()


