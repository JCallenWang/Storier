VAR hasInvestigateDesk = false
VAR hasInvestigateCabinet = false
VAR hasSeenMoffy = false

[全黑畫面，只有文字框顯示]<背景音:靈異>昏暗的事務所內，有個模糊的身影在來回走動
[氛圍:塑造像是有鬼入侵]它東翻西找，彷彿在尋回積欠的怨念
[氛圍:塑造像是有鬼入侵]<音效:怪物吼叫>"在..哪..."
<音效:翻箱倒櫃>
<音效:東西用力碰撞>
<背景音中斷>
[畫面漸漸出現]
[出現事務所的桌子、椅子、檔案櫃、但是沒有人影]
<背景音:事務所>"呃..."
[突然桌後伸出一隻手]<音效:威脅>J"..."
[那隻手緩緩地垂下桌面]
[操作提示:喚醒主角(左右鍵來回，直到手慢慢伸長並捉住桌面)]	//[如果玩家未操作>10sec] #ShowInstructionHint
[主角撐著桌面，甩頭]J"看來偵探真的不行了"
J"一定還有什麼漏掉的" -> Office_Investigate


===Office_Investigate===
* 調查桌面
	J"應該好好整理一下"
	J"要從這裡找到客戶是大海撈針"
	~hasInvestigateDesk = true
	->Office_Investigate
* 調查檔案櫃
	J"A客戶..B客戶..CDE..."
	J"還是我把這些客戶互相介紹，改作中間人"
	~hasInvestigateCabinet = true
	->Office_Investigate
+ 調查貓咪
	{hasSeenMoffy: <音效:貓叫>莫非發出呼嚕聲 -> Office_Investigate | -> Seen_Moffy} 
+ {Secret_CatGirl}調查窗戶
	[主角緩緩走向窗邊][莫非在後面跟著你]
	一針風吹來，窗外閃過一個人影並且影子尾端有一條黑色的長尾巴
	J"莫非阿莫非"
	莫非發出一聲貓叫
	->Office_Investigate
* {hasInvestigateDesk && hasInvestigateCabinet}調查電話
	[電話突然響起]
	J"您好，靈異事務所? 有甚麼奇怪的事情需要我來處理呢?"
	電話聲音"我見到了紅衣小女孩...我不想死...救救我"
	J"也該有一些奇怪的案子了"
	[主角放下電話，走向出口，隨手拿起一旁的偵探帽，走出了門]
	[門關上，畫面漸漸消失]
	[出現標題？]
	[進入下一幕：火車]
	-> END
	
===Secret_CatGirl===
[新增事務所窗戶可以互動]
->Office_Investigate

===Seen_Moffy===
~hasSeenMoffy = true
J"只有老莫非還願意待在我身邊"
莫非緩緩抬起頭，順著你的撫摸發出呼嚕聲
J:"什麼時候介紹一下你住在隔壁的新女友給我"
莫非停下呼嚕聲凝視著你，彷彿在思考剛剛的話
->Secret_CatGirl