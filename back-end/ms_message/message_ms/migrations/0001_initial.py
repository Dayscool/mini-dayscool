# Generated by Django 3.0.5 on 2020-09-29 03:32

from django.db import migrations, models
import django.db.models.deletion


class Migration(migrations.Migration):

    initial = True

    dependencies = [
    ]

    operations = [
        migrations.CreateModel(
            name='Conversation',
            fields=[
                ('id', models.AutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('usuario1Id', models.IntegerField()),
                ('usuario2Id', models.IntegerField()),
            ],
        ),
        migrations.CreateModel(
            name='Message',
            fields=[
                ('id', models.AutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('text', models.TextField()),
                ('sendDate', models.DateField()),
                ('remitenteId', models.IntegerField()),
                ('conversationId', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, to='message_ms.Conversation')),
            ],
        ),
    ]
