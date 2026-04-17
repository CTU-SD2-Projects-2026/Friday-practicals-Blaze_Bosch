import pyodbc

def connect_db():
    try:
        conn = pyodbc.connect(
            'DRIVER={SQL Server};'
            'SERVER=LAPTOP-D8O1G72G\\SQLEXPRESS;'
            'DATABASE=ApexLogisticsDB;'
            'Trusted_Connection=yes;'
        )
        return conn
    except Exception as e:
        print("Connection failed:", e)
        return None



if name == "main":
test_connection()
