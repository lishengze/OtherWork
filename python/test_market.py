import datetime

from WindPy  import *


def demo1():
    import pandas as pd

    import numpy as np

    date = datetime.today()

    all_a = w.wset("SectorConstituent",date = date ,sector=u"全部A股")

    

    all_Code = list(pd.Series(all_a.Data[1]))#获取的是列表数据

    
    all_tp = w.wset("TradeSuspend",startdate = date,enddate = date,field = "wind_code,sec_name,suspend_type,suspend_reason")

    all_tp_code = list(pd.Series(all_tp.Data[0]))

   
    all_st = w.wset("SectorConstituent",date=date,sector=u"风险警示股票",field="wind_code,sec_name")

    all_st_code = list(pd.Series(all_st.Data[0]))

   
    all_Code = set(all_Code)

    all_st_code =  set(all_st_code)

    all_tp_code = set(all_tp_code)

    code = all_Code - all_tp_code - all_st_code

  
    code = list(code)

    print("all_a_code: \n")
    print(all_Code)

def get_usa_code():
    date = datetime.today()

    usa_code = w.wset("SectorConstituent",date = date ,sector=u"全部美股")    
    print("usa_code: \n")
    print(usa_code)    
    
def get_beijing_code():
    date = datetime.today()

    usa_code = w.wset("sectorconstituent","date=2023-04-21;sectorid=1000045156000000")    
    print("beijiaosuo: \n")
    print(usa_code)        


if __name__ == '__main__':
    # demo1()
    # get_usa_code()
    get_beijing_code()