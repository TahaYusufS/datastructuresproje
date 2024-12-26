using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace öyylesine
{
    internal class EgeDeniziB
    {
        public string balıkAdı;

        public string bilgi;
        public string BalıkAdı {  get; set; }

        public Tree kelimelerAğacı;
        public Tree KelimelerAğacı { get; set; }

        

        public EgeDeniziB() {
          

        }

        public EgeDeniziB(string name, string words) 
        {//words'de balık hakkındaki bütün bilgiler tek paragraf olarak alınır, parçalara bölünüp döngülerle kelimelerAğacı'na eklenir.
           this.balıkAdı = name;
           Tree örnekAğaç = new Tree();//ağacı direk setleyemedim(getter - setterda sorun yaşadım) onun yerine örnek bir ağaç oluşturup onu sınıfın ağacına bağladım/setledim.(javadaki this mantığıyla ilerledim.)
            string[] asılKelimeler=divideWords(words);
          this.bilgi=words;
          
            foreach (var item in asılKelimeler)//paragraftaki asıl kelimeleri ağaca ekliyoruz
            {
               örnekAğaç.root=örnekAğaç.insert(örnekAğaç.root, item);
                //KelimelerAğacı.root=KelimelerAğacı.insert(KelimelerAğacı.root, item);
                //this.kelimelerAğacı.root=this.kelimelerAğacı.insert(this.kelimelerAğacı.root,item); //bunları denedim olmadı
                
            }
            this.kelimelerAğacı = örnekAğaç;


         




        }





        public string[] divideWords(string y) {

            string[] z = y.Split(new char[] { ' ', ',', '.', ';', ':','(',')','-','0','1','2','3','4','5','6','7','8','9' });//paragrafta kelime olmayan yerleri ayrıştırıyoruz
            string[] realWrods;//yukardaki split metodunda fazladan null("") durumları ortaya çıktı null harici asıl kelimeleri buraya atacağım.
            int count = 0;



            for (int i = 0; i < z.Length; i++)//asıl kelime sayısını buluyoruz.
            {

                if (z[i] != "" )
                {
                    count++;
                }
            }
            realWrods = new string[count];//initialize işlemi tamamlandı

            int sayaç = 0;//realWords'de dolaşmak için bir tane daha sayaç attım
            for (int i = 0; i < z.Length; i++)//bu noktada count elde edildi ve asıl kelimeler için kontrol işlemi başladı
            {

                if (z[i] != "")
                {
                    realWrods[sayaç] = z[i];
                    sayaç++;
                }
            }

            return realWrods;

        }




    }
}
