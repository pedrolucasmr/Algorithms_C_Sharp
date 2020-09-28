import configparser as _configParser

def readDbConfig(file="../Data/config.ini",section='mysql'):
    parser=_configParser.ConfigParser()
    parser.read(file)
    db={}
    if parser.has_section(section):
        items=parser.items(section)
        for item in items:
            db[item[0]] = item[1]
    else:
        raise Exception('{0} not found in the {1} file'.format(section, file))
    return db
