#!/usr/bin/python
# -*- coding: UTF-8 -*-

import json

from openpyxl.descriptors.base import String

class VariableType:

    def __init__(self):
        pass
    
    def default(self) -> str:
        pass    

    def check(self, type) -> bool:
        pass

    def to_json(self, value) -> any:
        pass

    def to_client_script(self, type: str, name: str, comment: str) -> str:
        pass

    def to_server_script(self, type: str, name: str, comment: str) -> str:
        pass

class BoolType:
    
    def __init__(self):
        pass

    def default(self):
        return 'FALSE'    

    def check(self, type):
        return type == 'bool'

    def to_json(self, value):
        return bool(value)
        
    def to_client_script(self, type, name, comment):
        prop_define ='\n\n\tprivate bool m_{0};\n\t/// <summary>\n\t/// {1}\n\t/// <summary>\n\tpublic bool {0} => m_{0};'.format(name, comment)
        prop_parse ='\n\t\tm_{0} = bool.Parse(columnStrings[index++]);'.format(name)
        return prop_define, prop_parse

    def to_server_script(self, name):
        pass

class IntType:
    
    def __init__(self):
        pass

    def default(self):
        return '0'    

    def check(self, type):
        return type == 'int'

    def to_json(self, value):
        return int(value)

    def to_client_script(self, type, name, comment):
        prop_define ='\n\n\tprivate int m_{0};\n\t/// <summary>\n\t/// {1}\n\t\t/// <summary>\n\tpublic int {0} => m_{0};'.format(name, comment)
        prop_parse ='\n\t\tm_{0} = int.Parse(columnStrings[index++]);'.format(name)
        return prop_define, prop_parse

    def to_server_script(self, name):
        pass

class StringType:
    
    def __init__(self):
        pass

    def default(self):
        return ''

    def check(self, type):
        return type == 'string'

    def to_json(self, value):
        return value

    def to_client_script(self, type, name, comment):
        prop_define ='\n\n\tprivate string m_{0};\n\t/// <summary>\n\t/// {1}\n\t/// <summary>\n\tpublic string {0} => m_{0};'.format(name, comment)
        prop_parse ='\n\t\tm_{0} = columnStrings[index++];'.format(name)
        return prop_define, prop_parse

    def to_server_script(self, name):
        pass
    
class FloatType:
    
    def __init__(self):
        pass

    def default(self):
        return '0'    

    def check(self, type):
        return type == 'float'

    def to_json(self, value):
        return float(value)

    def to_client_script(self, type, name, comment):
        prop_define ='\n\n\tprivate float m_{0};\n\t/// <summary>\n\t/// {1}\n\t/// <summary>\n\tpublic float {0} => m_{0};'.format(name, comment)
        prop_parse ='\n\t\tm_{0} = float.Parse(columnStrings[index++]);'.format(name)
        return prop_define, prop_parse

    def to_server_script(self, name):
        pass

class LongType:
    
    def __init__(self):
        pass

    def default(self):
        return '0'    

    def check(self, type):
        return type == 'long'

    def to_json(self, value):
        return int(value)

    def to_client_script(self, type, name, comment):
        prop_define ='\n\n\tprivate long m_{0};\n\t/// <summary>\n\t/// {1}\n\t/// <summary>\n\tpublic long {0} => m_{0};'.format(name, comment)
        prop_parse ='\n\t\tm_{0} = long.Parse(columnStrings[index++]);'.format(name)
        return prop_define, prop_parse

    def to_server_script(self, name):
        pass

class DoubleType:
    
    def __init__(self):
        pass

    def default(self):
        return '0'    

    def check(self, type):
        return type == 'double'

    def to_json(self, value):
        return float(value)

    def to_client_script(self, type, name, comment):
        prop_define ='\n\n\tprivate double m_{0};\n\t/// <summary>\n\t/// {1}\n\t/// <summary>\n\tpublic double {0} => m_{0};'.format(name, comment)
        prop_parse ='\n\t\tm_{0} = double.Parse(columnStrings[index++]);'.format(name)
        return prop_define, prop_parse

    def to_server_script(self, name):
        pass

class ArrayType:
    
    def __init__(self):
        pass

    def default(self):
        return '[]' 

    def check(self, type: String):
        return type.startswith('array')

    def to_json(self, value):
        return json.loads(value)

    def to_client_script(self, type, name, comment):
        left_index = type.rfind('[')
        right_index = type.rfind(']')
        type = type[left_index + 1:right_index]
        prop_define ='\n\n\tprivate {2}[] m_{0};\n\t/// <summary>\n\t/// {1}\n\t/// <summary>\n\tpublic {2}[] {0} => m_{0};'.format(name, comment, type)
        prop_parse ='\n\t\tm_{0} = JsonConvert.DeserializeObject<{1}[]>(columnStrings[index++]);'.format(name, type)
        return prop_define, prop_parse

    def to_server_script(self, name):
        pass

class ObjectType:
    
    def __init__(self):
        pass

    def default(self):
        return '{}' 
           
    def check(self, type: String):
        return type.startswith('object')

    def to_json(self, value):
        return json.loads(value)

    def to_client_script(self, type, name, comment):
        left_index = type.rfind('[')
        right_index = type.rfind(']')
        type = type[left_index + 1:right_index]
        prop_define ='\n\n\tprivate {2} m_{0};\n\t/// <summary>\n\t/// {1}\n\t/// <summary>\n\tpublic {2} {0} => m_{0};'.format(name, comment, type)
        prop_parse ='\n\t\tm_{0} = JsonConvert.DeserializeObject<{1}>(columnStrings[index++]);'.format(name, type)
        return prop_define, prop_parse

    def to_server_script(self, name):
        pass

class I18NType:
    
    def __init__(self):
        pass

    def default(self):
        return '' 

    def check(self, type: String):
        return type == 'i18n'

    def to_json(self, value):
        return value

    def to_client_script(self, type, name, comment):
        prop_define ='\n\n\tprivate string m_{0};\n\t/// <summary>\n\t/// {1}\n\t/// <summary>\n\tpublic string {0} => m_{0};'.format(name, comment)
        prop_parse ='\n\t\tm_{0} = columnStrings[index++];'.format(name)
        return prop_define, prop_parse

    def to_server_script(self, name):
        pass
