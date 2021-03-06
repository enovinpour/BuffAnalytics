﻿CREATE EVENT SESSION [QuickSessionTSQL] ON SERVER 
ADD EVENT [sqlserver].[error_reported]
    (
    ACTION ([package0].[callstack],
            [sqlserver].[session_id],
            [sqlserver].[database_id],
            [sqlserver].[sql_text],
            [sqlserver].[tsql_stack])
    WHERE ([severity]>=(20) OR ([error_number]=(17803) OR [error_number]=(701) OR [error_number]=(802) OR [error_number]=(8645) OR [error_number]=(8651) OR [error_number]=(8657) OR [error_number]=(8902) OR [error_number]=(41354) OR [error_number]=(41355) OR [error_number]=(41367) OR [error_number]=(41384) OR [error_number]=(41336) OR [error_number]=(41309) OR [error_number]=(41312) OR [error_number]=(41313)))
    ), 
ADD EVENT [sqlserver].[existing_connection]
    (
    ACTION ([package0].[event_sequence],
            [sqlserver].[session_id],
            [sqlserver].[client_hostname])
    ), 
ADD EVENT [sqlserver].[login]
    (
    SET collect_options_text = 1
    ACTION ([package0].[event_sequence],
            [sqlserver].[session_id],
            [sqlserver].[client_hostname])
    ), 
ADD EVENT [sqlserver].[logout]
    (
    ACTION ([package0].[event_sequence],
            [sqlserver].[session_id])
    ), 
ADD EVENT [sqlserver].[rpc_starting]
    (
    ACTION ([package0].[event_sequence],
            [sqlserver].[session_id],
            [sqlserver].[database_name])
    WHERE ([package0].[equal_boolean]([sqlserver].[is_system],(0)))
    ), 
ADD EVENT [sqlserver].[sql_batch_starting]
    (
    ACTION ([package0].[event_sequence],
            [sqlserver].[session_id],
            [sqlserver].[database_name])
    WHERE ([package0].[equal_boolean]([sqlserver].[is_system],(0)))
    )
WITH  (
        MAX_MEMORY = 16 MB,
        EVENT_RETENTION_MODE = ALLOW_SINGLE_EVENT_LOSS,
        MAX_DISPATCH_LATENCY = 5 SECONDS,
        MEMORY_PARTITION_MODE = PER_CPU,
        TRACK_CAUSALITY = ON,
        STARTUP_STATE = OFF
      );

