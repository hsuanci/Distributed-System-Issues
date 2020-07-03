# Distributed-System-Issues
## Update Table issue
* 情況假設
假設A有100元餘額於資料庫中
現在ServerA & ServerB 中共同有個FunctionAdd (將客戶餘額加上20)
接下來有兩個rqs同時sent至A & B 

理論上會發生這樣情況
ServerA執行時取得A餘額100加上20, 而後將資料庫A餘額更新為120
同時ServerB執行時取得A餘額100加上20, 也把資料庫A餘額更新為120
以上這個情境錯誤(同時取得餘額為100)

希望執行的狀況
ServerA執行時取得A餘額100加上20, 而後將資料庫A餘額更新為120
待ServerA執行後ServerB才去取得餘額120加上20，將資料庫A餘額更新為140
[Lock DB Reference](https://jackyshih.pixnet.net/blog/post/6154337)
* 解決方案 - 
1. 如本Project, 判斷update, 用while迴圈重新call
2. RabbitMQ queue