% ��������� �������
M = [
    0     0 0   ; 0     0.5 37.5; 0     1 75;
    13.41 0 12.5; 13.41 0.5 50  ; 13.41 1 87.5;
    35    0 25  ; 35    0.5 62.5; 35    1 100];

% ������������ �������� ��� ��� ������� ������
in1LowFisMax = 23.98;
in2LowFisMax = 96.86;

% ������������ �������� ��� ��� �������� ������
in2HighMax = 1;

% ��� ������� ������
lowFis = readfis('BatulevTrainFis');

% ��������� ������ ��� ��� �������� ������
X = [0; 13.41; 35];
Y = [0; 0.5;   1];

% ��������� �������
train = GetSampleDataForHighFis(lowFis,in1LowFisMax,in2LowFisMax,in2HighMax,X,Y,M);
% ����������� �������
test = GetSampleDataForHighFis(lowFis,in1LowFisMax,in2LowFisMax,in2HighMax,X,Y,M);

% ��� �������� ������
highFis = readfis('brakingDistancesFis');
fuzzy(highFis);

