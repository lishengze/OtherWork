# coding=gbk
# coding=utf8

import datetime
from WindPy import *

def has_number(src):
    number_list = ['0', '1','2','3','4','5','6','7','8','9']
    for number in number_list:
        if number in src:
            return True
    return False

def test_has_number():
    test_list = ["A0b", "1As", "ab5", "ABF", "A__D", "sba"]
    for test_case in test_list:
        print(test_case, has_number(test_case))

def get_suffix_list(code_list):
    rst = {}
    for code in code_list:
        item_list = code.split(".")
        if len(item_list) == 2:
            suffix = item_list[1]
            code_name = item_list[0]
            if suffix not in rst:
                rst[suffix] = []
                rst[suffix].append(len(code_name))
            elif len(code_name) not in rst[suffix]:
                rst[suffix].append(len(code_name))
            
            # rst[0].append(item_list[1])
            
            if suffix == 'N' or suffix == 'O' or suffix=='A':
                if has_number(code_name):
                    print(item_list)
                    
        # if len(item_list) == 2 and len(item_list[0]) not in rst[1]:
        #     rst[1].append(len(item_list[0]))
            
    return rst

def get_usa_code():
    
    rst = w.start()
    print(rst)
    
    cur_date = datetime.today()
    # codes = w.wset("SectorConstituent", date=cur_date, sector=u"全部A股")
    # print(codes)
    
    # data = w.wss("BILI.O", "pre_close,open,high,low,close","tradeDate=20230318;priceAdj=U;cycle=D")
    # print(data)
    
    data = w.wsd("AAIC.N", "close", "2023-03-15", "2023-03-18", "TradingCalendar=NASDAQ")
    print(data)
    print("\n")

    data = w.wsd("AAIC.N", "close", "2023-03-15 8:00:00", "2023-03-15 17:00:00", "Fill=Previous")
    print(data)
    print("\n")
    
    data = w.wsq("600000.SH", "rt_last", "Fill=Previous")
    print(data)
    print("\n")    
        
    # A股
    # data = w.wset("sectorconstituent","date=2023-03-19;sectorid=a001010100000000")
    # print(get_suffix_list(data.Data[1]))
    # print("\n")
    
    # # 美股
    # data = w.wset("sectorconstituent","date=2023-03-19;sectorid=1000022276000000")
    # usa_code_list = data.Data[1]
    
    # print(get_suffix_list(data.Data[1]))

    # print("\n")
    
    # # 港股
    # data =w.wset("sectorconstituent","date=2023-03-19;sectorid=a002010100000000")
    # hk_code_list = data.Data[1]
    # print(get_suffix_list(data.Data[1]))
    
    # print(data.Data[1])
    print("\n")    

if __name__ == '__main__':
    test_has_number()
    # demo1()
    get_usa_code()