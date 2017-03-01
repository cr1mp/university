% Априорная выборка
M = [
    0     0 0   ; 0     0.5 37.5; 0     1 75;
    13.41 0 12.5; 13.41 0.5 50  ; 13.41 1 87.5;
    35    0 25  ; 35    0.5 62.5; 35    1 100];

% Максимальные значение для фис низкого уровня
in1LowFisMax = 23.98;
in2LowFisMax = 96.86;

% Максимальное значение для фис высокого уровня
in2HighMax = 1;

% фис низкого уровня
lowFis = readfis('BatulevTrainFis');

% Максимумы термов для фис высокого уровня
X = [0; 13.41; 35];
Y = [0; 0.5;   1];

% обучающая выборка
train = GetSampleDataForHighFis(lowFis,in1LowFisMax,in2LowFisMax,in2HighMax,X,Y,M);
% тестирующая выборка
test = GetSampleDataForHighFis(lowFis,in1LowFisMax,in2LowFisMax,in2HighMax,X,Y,M);

% фис высокого уровня
highFis = readfis('brakingDistancesFis');
fuzzy(highFis);

