
-- Make sure to execute first schema.sql
\c transport_dev

-- Insert transport companies
INSERT INTO transport.companies (name, address, phone, email)
VALUES
    ('Transportes R�pidos SL', 'Calle Log�stica 123, Madrid', '+34911234567', 'info@transportesrapidos.com'),
    ('Env�os Seguros SA', 'Avenida Distribuci�n 45, Barcelona', '+34932234567', 'contacto@enviosseguros.com'),
    ('Carga Eficiente SL', 'Pol�gono Industrial Norte, Valencia', '+34963345678', 'operaciones@cargaeficiente.com');

-- Insert drivers
INSERT INTO transport.drivers (first_name, last_name, license_number, phone, email, hire_date, status)
VALUES
    ('Juan', 'P�rez', 'LIC-123456', '+34611223344', 'juan.perez@transportesrapidos.com', '2020-01-15', 'ACTIVE'),
    ('Mar�a', 'G�mez', 'LIC-234567', '+34622334455', 'maria.gomez@transportesrapidos.com', '2019-05-22', 'ACTIVE'),
    ('Carlos', 'L�pez', 'LIC-345678', '+34633445566', 'carlos.lopez@enviosseguros.com', '2021-03-10', 'VACATION'),
    ('Ana', 'Mart�nez', 'LIC-456789', '+34644556677', 'ana.martinez@cargaeficiente.com', '2022-01-30', 'ACTIVE'),
    ('Pedro', 'S�nchez', 'LIC-567890', '+34655667788', 'pedro.sanchez@transportesrapidos.com', '2018-11-05', 'INACTIVE');

-- Insert trucks
INSERT INTO transport.trucks (license_plate, make, model, year, capacity_kg, status, last_maintenance_date, next_maintenance_date)
VALUES
    ('1234ABC', 'Volvo', 'FH16', 2020, 40000.00, 'AVAILABLE', '2023-01-15', '2023-07-15'),
    ('2345BCD', 'MAN', 'TGX', 2019, 35000.00, 'IN_USE', '2023-02-20', '2023-08-20'),
    ('3456CDE', 'Scania', 'R450', 2021, 42000.00, 'AVAILABLE', '2023-03-10', '2023-09-10'),
    ('4567DEF', 'Mercedes-Benz', 'Actros', 2018, 38000.00, 'IN_MAINTENANCE', '2022-12-05', '2023-06-05'),
    ('5678EFG', 'Iveco', 'S-WAY', 2022, 39000.00, 'AVAILABLE', '2023-04-01', '2023-10-01');

-- Insert deliveries
INSERT INTO transport.deliveries (
    reference_number, departure_address, destination_address,
    departure_time, estimated_time_arrival, status,
    driver_id, truck_id, company_id, cargo_description,
    weight_kg, total_distance_km, fee_euros
)
VALUES
    ('DEL-20230001', 'Calle Industria 23, Madrid', 'Avenida Comercial 45, Barcelona',
     '2023-06-01 08:00:00+02', '2023-06-01 14:00:00+02', 'COMPLETED',
     1, 1, 1, 'Electr�nica de consumo', 12500.50, 620.5, 850.00),
     
    ('DEL-20230002', 'Pol�gono Industrial Norte, Valencia', 'Zona Franca, Zaragoza',
     '2023-06-02 09:30:00+02', '2023-06-02 12:30:00+02', 'IN_PROGRESS',
     2, 2, 2, 'Piezas de autom�vil', 18500.75, 320.0, 600.50),
     
    ('DEL-20230003', 'Puerto de Bilbao', 'Centro de Distribuci�n Sur, Sevilla',
     '2023-06-03 07:00:00+02', '2023-06-03 18:00:00+02', 'PLANNED',
     4, 3, 3, 'Muebles de oficina', 22000.00, 850.0, 1200.00),
     
    ('DEL-20230004', 'Nave Log�stica 5, Valladolid', 'Pol�gono Industrial Este, M�laga',
     '2023-06-01 10:00:00+02', '2023-06-01 20:00:00+02', 'COMPLETED',
     1, 5, 1, 'Material de construcci�n', 30000.25, 720.0, 950.75),
     
    ('DEL-20230005', 'Centro de Distribuci�n Norte, Burgos', 'Pol�gono Industrial Oeste, A Coru�a',
     '2023-06-04 06:00:00+02', '2023-06-04 12:00:00+02', 'PLANNED',
     4, 1, 3, 'Productos alimenticios', 15000.00, 550.0, 700.00);
