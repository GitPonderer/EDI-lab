import csv
import pathlib

def test_csv():
    f = pathlib.Path("/Users/mikolajsoltysiuk/dev/EDI-lab/Week1/bots-lab/outbox/1.csv")
    rows = list(csv.reader(f.open()))
    assert rows[0][1] == "128576"  # Check order number in first row
    assert rows[0][2] == "20020830"  # Check order date in first row