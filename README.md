# RTB
> 余庭光 Tim Yu
## 使用方式
* 先確認您有安裝Docker，並啟動Docker
* 把此Repository Pull下來，cd進第一層
```bash=
cd ExchangeServer (若要啟動BidderServer，以下指令皆要相應調整，BidderServer port: 8887)
```
* Dockerfile已寫好，執行build
```bash=
docker build -t exchangeserver .
```
* build結束後直接以下run指令便可運行sever
```bash=
docker run -d --name exchangeserver -p 8888:8888 exchangeserver
```
* server運作於localhost:8888 ，在瀏覽器輸入localhost:8888/swagger可進入類似postman可輕鬆執行API的介面

## 參考
[參考](https://intowow.notion.site/Simple-RTB-9ac8484091544c7c9daaebe056f2cba4)
