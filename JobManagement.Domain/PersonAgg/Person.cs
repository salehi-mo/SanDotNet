using _0_Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobManagement.Domain.PersonOzvNoaAgg;
using JobManagement.Domain.PersonEshtegVazAgg;
using JobManagement.Domain.QorbAgg;
using JobManagement.Domain.QorbMoasAgg;
using JobManagement.Domain.QorbMoasPorAgg;
using JobManagement.Domain.QorbMoasPorKarAgg;

namespace JobManagement.Domain.PersonAgg
{
    public class Person : EntityBase
    {
        public long PerId { get; private set; }
        public string Nam { get; private set; }
        public string Fam { get; private set; }
        public string NamPed { get; private set; }
        public string NoShe { get; private set; }
        public string CodMelli { get; private set; }
        public string Slug { get; private set; }


        public long? PersonOzvNoaId { get; private set; }
        public PersonOzvNoa PersonOzvNoa { get; private set; }
        public long? PersonEshtegVazId { get; private set; }
        public PersonEshtegVaz PersonEshtegVaz { get; private set; }

        public long? QorbId { get; private set; }
        public Qorb Qorb { get; private set; }

        public long? QorbMoasId { get; private set; }
        public QorbMoas QorbMoas { get; private set; }

        public long? QorbMoasPorId { get; private set; }
        public QorbMoasPor QorbMoasPor { get; private set; }

        public long? QorbMoasPorKarId { get; private set; }
        public QorbMoasPorKar QorbMoasPorKar { get; private set; }


        public Person()
        {

        }

        public Person(long perId, string nam, string fam, string namPed, string noShe, string codMelli, long personOzvNoaId, long personEshtegVazId, long qorbId, long qorbMoasId, long qorbMoasPorId, long qorbMoasPorKarId, string slug)
        {
            PerId = perId;
            Nam = nam;
            Fam = fam;
            NamPed = namPed;
            NoShe = noShe;
            CodMelli = codMelli;
            Slug = slug;
            PersonOzvNoaId = personOzvNoaId;
            PersonEshtegVazId = personEshtegVazId;
            QorbId = qorbId;
            QorbMoasId = qorbMoasId;
            QorbMoasPorId = qorbMoasPorId;
            QorbMoasPorKarId = qorbMoasPorKarId;
        }

        
       
        public void Edit(long perId, string nam, string fam, string namPed, string noShe, string codMelli, long personOzvNoaId, long personEshtegVazId, long qorbId, long qorbMoasId, long qorbMoasPorId, long qorbMoasPorKarId, string slug)
        {
            PerId = perId;
            Nam = nam;
            Fam = fam;
            NamPed = namPed;
            NoShe = noShe;
            CodMelli = codMelli;
            Slug = slug;
            PersonOzvNoaId = personOzvNoaId;
            PersonEshtegVazId = personEshtegVazId;
            QorbId = qorbId;
            QorbMoasId = qorbMoasId;
            QorbMoasPorId = qorbMoasPorId;
            QorbMoasPorKarId = qorbMoasPorKarId;
        }
    }
}
