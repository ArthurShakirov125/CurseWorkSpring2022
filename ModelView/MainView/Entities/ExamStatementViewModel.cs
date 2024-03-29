﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdmissionsCommittee.Abstract;
using AdmissionsCommittee.DataBase;

namespace AdmissionsCommittee.ModelView.MainView
{
    public class ExamStatementViewModel : EntityModelView<Exam_statement>
    {
        public ExamStatementViewModel(Exam_statement model) : base(model)
        {
        }

        public Exam_statement examStatement
        {
            get { return _model; }
            set
            {
                _model = value;
                OnPropertyChanged();
            }
        }


        public short? Points
        {
            get { return _model.Points; }
            set
            {
                _model.Points = value;
                OnPropertyChanged();
            }
        }

        public byte? Mark
        {
            get { return _model.Mark; }
            set
            {
                _model.Mark = value;
                OnPropertyChanged();
            }
        }

        public string EnrolleLastName
        {
            get { return _model.Enrolle_last_name; }
            set
            {
                _model.Enrolle_last_name = value;
                OnPropertyChanged();
            }
        }

        public int EnrolleeNumber
        {
            get { return _model.Exam_sheet_number; }
            set
            {
                _model.Exam_sheet_number = value;
                OnPropertyChanged();
            }
        }

    }
}
