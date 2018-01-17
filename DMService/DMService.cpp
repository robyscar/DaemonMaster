// DMService.cpp: Definiert den Einstiegspunkt für die Konsolenanwendung.
//


#include "stdafx.h"
#include "Service.h"

#define PLACEHOLDER_SERVICE_NAME L"DaemonMaster ProService"

int wmain(int argc, wchar_t *argv[], wchar_t *envp[])
{
	if(argc >1)
	{
		if(_wcsicmp(L"-console", argv[1]) == 0)
		{
			//Nothing
			return 0;
		}
		else if(_wcsicmp(L"-service", argv[1]) == 0)
		{
			Service service(const_cast<wchar_t*>(PLACEHOLDER_SERVICE_NAME));
			if(!service.Run(service))
			{
				throw GetLastError();
			}
		}
	}

	return 0;
}

