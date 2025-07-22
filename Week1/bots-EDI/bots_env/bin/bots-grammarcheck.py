#!/Users/mikolajsoltysiuk/dev/EDI-lab/Week1/bots-EDI/bots_env/bin/python3.12
# -*- coding: utf-8 -*-

from bots import grammarcheck

if __name__ == '__main__':
    grammarcheck.start()
    #~ grammarcheck.startmulti('bots/usersys/grammars/edifact/*','edifact')     #for bulk check of grammars
